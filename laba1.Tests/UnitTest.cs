using NUnit.Framework;
using NSubstitute;
using System;
using ExceptionManager;

namespace ExceptionManager.Tests
{
    [TestFixture]
    public class ExceptionManagerTests
    {
        private ExceptionManager managerTrue =
            ExceptionManagerFactory.CreateStubExceptionManagerTrue();

        private ExceptionManager managerFalse =
            ExceptionManagerFactory.CreateStubExceptionManagerFalse();

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

        [Test]
        public void Handle_NullArgument_ReturnsNothing()
        {
            ExceptionManager manager = new ExceptionManager{};
            var before = manager.GetStats();
            //Act
            managerTrue.Handle(null);
            //Assert
            var after = manager.GetStats();
            Assert.That(before, Is.EqualTo(after));
        }

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

        [Test, TestCaseSource("criticalExceptions")]
        public void ErrorCounter_Increment(Exception ex)
        {
            UInt16 errorCounter = 0;
            ICriticalExceptionInformer exceptionInformer = Substitute.For<ICriticalExceptionInformer>();

            exceptionInformer.When(exceptionInformer => exceptionInformer.Inform(Arg.Any<Exception>()))
                .Do(exceptionInformer => errorCounter++);


            ExceptionManager manager = new ExceptionManager
            {
                ExceptionInformer = exceptionInformer
            };

            UInt16 before = errorCounter;

            exceptionInformer.Inform(Arg.Any<Exception>()).Returns(false);
            manager.Inform(ex);
            exceptionInformer.Received().Inform(ex);

            Assert.That(errorCounter, Is.EqualTo(before + 1));

            
        }
    }
}