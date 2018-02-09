using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes.Vending_Machine_Items;

namespace CapstoneTests.Tests
{
    [TestClass]
    public class BeverageItemTests
    {

        BeverageItem testClass;

        [TestInitialize]
        public void Initialize()
        {
            testClass = new BeverageItem("", 0.0M);
        }

        [TestMethod]
        public void BeverageReturnsConsumeMessage()
        {
            Assert.AreEqual("Glug Glug, Yum!", testClass.Consume());
        }

        [TestMethod]
        public void BeveragePropertiesFunctional()
        {
            Assert.AreEqual("", testClass.ItemName);
            Assert.AreEqual(0.0M, testClass.Price);
        }
    }
}
