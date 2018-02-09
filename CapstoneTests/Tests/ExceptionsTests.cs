using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes.Exceptions;

namespace CapstoneTests.Tests
{
    [TestClass]
    public class ExceptionsTests
    {

        InsufficientFundsException testClass;
        OutOfStockException testClass1;

        [TestInitialize]
        public void Initialize()
        {
            testClass = new InsufficientFundsException();
            testClass1 = new OutOfStockException();

        }

        [TestMethod]
        public void ExceptionsReturnMessage()
        {
            Assert.AreEqual("Exception of type 'Capstone.Classes.Exceptions.InsufficientFundsException' was thrown.", testClass.Message);
            Assert.AreEqual("Exception of type 'Capstone.Classes.Exceptions.OutOfStockException' was thrown.", testClass1.Message);


        }
    }
}
