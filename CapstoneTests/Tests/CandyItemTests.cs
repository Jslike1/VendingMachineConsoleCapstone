using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes.Vending_Machine_Items;

namespace CapstoneTests.Tests
{
    [TestClass]
    public class CandyItemTests
    {

        CandyItem testClass;

        [TestInitialize]
        public void Initialize()
        {
            testClass = new CandyItem("", 0.0M);
        }

        [TestMethod]
        public void CandyReturnsConsumeMessage()
        {
            Assert.AreEqual("Munch Munch, Yum!", testClass.Consume());
        }

        [TestMethod]
        public void CandyPropertiesFunctional()
        {
            Assert.AreEqual("", testClass.ItemName);
            Assert.AreEqual(0.0M, testClass.Price);
        }
    }
}
