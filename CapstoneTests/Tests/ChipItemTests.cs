using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes.Vending_Machine_Items;

namespace CapstoneTests.Tests
{
    [TestClass]
    public class ChipItemTests
    {

        ChipItem testClass;

        [TestInitialize]
        public void Initialize()
        {
            testClass = new ChipItem("", 0.0M);
        }


        [TestMethod]
        public void ChipReturnsConsumeMessage()
        {
            Assert.AreEqual("Crunch Crunch, Yum!", testClass.Consume());
        }

        [TestMethod]
        public void ChipPropertiesFunctional()
        {
            Assert.AreEqual("", testClass.ItemName);
            Assert.AreEqual(0.0M, testClass.Price);
        }
    }
}
