using NUnit.Framework;
using System;
using laba1;

namespace laba1.Tests
{
    [TestFixture]
    public class ExceptionManagerTests
    {
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
            ExceptionManager exceptionManager = new ExceptionManager();
            //Act
            Boolean result = exceptionManager.IsCritical(ex);
            //Assert
            Assert.That(result, Is.True);
        }

        [Test, TestCaseSource("ordinaryExceptions")]
        public void Iscritical_ordinatyException_returnsFalse(Exception ex)
        {
            ExceptionManager exceptionManager = new ExceptionManager();
            //Act
            Boolean result = exceptionManager.IsCritical(ex);
            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void Handle_CriticalException_IncrimentsCriticalExceptionCounter()
        {
            ExceptionManager exceptionManager = new ExceptionManager();
            //Arrange
            UInt16 before = exceptionManager.GetCounts().critical;
            Exception ex = new DivideByZeroException();
            //Act
            exceptionManager.Handle(ex);
            UInt16 result = exceptionManager.GetCounts().critical;
            //Assert
            Assert.That(result, Is.EqualTo(before + 1));
        }

        [Test]
        public void Handle_OrdinatyException_IncrimentsOrdinaryExceptionCounter()
        {
            ExceptionManager exceptionManager = new ExceptionManager();
            //Arrange
            UInt16 before = exceptionManager.GetCounts().ordinary;
            Exception ex = new NullReferenceException();
            //Act
            exceptionManager.Handle(ex);
            UInt16 result = exceptionManager.GetCounts().ordinary;
            //Assert
            Assert.That(result, Is.EqualTo(before + 1));
        }
    }
}