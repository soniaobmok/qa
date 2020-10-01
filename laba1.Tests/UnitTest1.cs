using NUnit.Framework;
using System;
using laba1;

namespace laba1.Tests
{
    [TestFixture]
    public class ExceptionManagerTests
    {
        [Test]
        public void IsCritical_DivideByZeroException_returnsTrue()
        {
            //Arrange
            Exception ex = new DivideByZeroException();
            //Act
            Boolean result = ExceptionManager.IsCritical(ex);
            //Assert
            Assert.That(result,Is.True);
        }

        [Test]
        public void IsCritical_FormatException_returnsTrue()
        {
            //Arrange
            Exception ex = new FormatException();
            //Act
            Boolean result = ExceptionManager.IsCritical(ex);
            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsCritical_ArithmeticException_returnsTrue()
        {
            //Arrange
            Exception ex = new ArithmeticException();
            //Act
            Boolean result = ExceptionManager.IsCritical(ex);
            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsCritical_NullReferenceException_returnsFalse()
        {
            //Arrange
            Exception ex = new NullReferenceException();
            //Act
            Boolean result = ExceptionManager.IsCritical(ex);
            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void Handle_CriticalException_IncrimentsCriticalExceptionCounter()
        {
            //Arrange
            Int16 before = ExceptionManager.GetCounts().critical;
            Exception ex = new DivideByZeroException();
            //Act
            ExceptionManager.Handle(ex);
            Int16 result = ExceptionManager.GetCounts().critical;
            //Assert
            Assert.That(result, Is.EqualTo(before + 1));
        }

        [Test]
        public void Handle_OrdinatyException_IncrimentsOrdinaryExceptionCounter()
        {
            //Arrange
            Int16 before = ExceptionManager.GetCounts().ordinary;
            Exception ex = new NullReferenceException();
            //Act
            ExceptionManager.Handle(ex);
            Int16 result = ExceptionManager.GetCounts().ordinary;
            //Assert
            Assert.That(result, Is.EqualTo(before + 1));
        }
    }
}