using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes.Vending_Machine_Items;

namespace CapstoneTests.Tests
{
    [TestClass]
    public class GumItemTests
    {

        GumItem testClass;

        [TestInitialize]
        public void Initialize()
        {
            testClass = new GumItem("", 0.0M);
        }

        [TestMethod]
        public void GumConsumeReturnsConsume()
        {
            Assert.AreEqual("Chew Chew, Yum!", testClass.Consume());
        }

        [TestMethod]
        public void GumPropertiesFunctional()
        {
            Assert.AreEqual("", testClass.ItemName);
            Assert.AreEqual(0.0M, testClass.Price);
        }
    }
}
