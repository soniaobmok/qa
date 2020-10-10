using NUnit.Framework;
using System;
using ExceptionManager;

namespace ExceptionManager.Tests
{
    [TestFixture]
    public class ExceptionManagerTests
    {
        private ExceptionManager managerTrue = new ExceptionManager
        (
            new CriticalExceptionStubDeterminatorTrue(),
            new CriticalExceptionStubInformerTrue()
        );

        private ExceptionManager managerFalse = new ExceptionManager
        (
            new CriticalExceptionStubDeterminatorFalse(),
            new CriticalExceptionStubInformerFalse()
        );

        private readonly static object[] criticalExceptions =
        {
            new object[] {new DivideByZeroException()},
            new object[] {new FormatException()},
            new object[] {new ArithmeticException()},
        };

        private readonly static object[] ordinaryExceptions =
        {
            new object[] {new NullReferenceException()},
            new object[] {new InvalidCastException()},
            new object[] {new IndexOutOfRangeException()},
        };

        [Test, TestCaseSource("criticalExceptions")]
        public void Iscritical_criticalException_returnsTrue(Exception ex)
        {
            //Act
            Boolean result = managerTrue.IsCritical(ex);
            //Assert
            Assert.That(result, Is.True);
        }

        [Test, TestCaseSource("ordinaryExceptions")]
        public void Iscritical_ordinatyException_returnsFalse(Exception ex)
        {
            //Act
            Boolean result = managerFalse.IsCritical(ex);
            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void Handle_CriticalException_IncrimentsCriticalExceptionCounter()
        {
            //Arrange
            Exception ex = new DivideByZeroException();
            UInt16 before = managerTrue
                .GetStats()
                .critical;
            //Act
            UInt16 result = managerTrue
                .Handle(ex)
                .GetStats()
                .critical;
            //Assert
            Assert.That(result, Is.EqualTo(before + 1));
        }

        [Test]
        public void Handle_OrdinatyException_IncrimentsOrdinaryExceptionCounter()
        {
            //Arrange
            UInt16 before = managerFalse
                .GetStats()
                .ordinary;
            Exception ex = new NullReferenceException();
            //Act
            ;
            UInt16 result = managerFalse
                .Handle(ex)
                .GetStats().ordinary;
            //Assert
            Assert.That(result, Is.EqualTo(before + 1));
        }
    }
}