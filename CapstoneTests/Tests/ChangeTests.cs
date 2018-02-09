using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests.Tests
{
    [TestClass]
    public class ChangeTests
    {
        Change change;

        [TestMethod]
        public void CheckOneDollar()
        {
            change = new Change(1.00m);
            Assert.AreEqual(4, change.Quarters);
            Assert.AreEqual(0, change.Dimes);
            Assert.AreEqual(0, change.Nickels);

        }

        [TestMethod]
        public void CheckFiveDollars()
        {
            change = new Change(5.00m);
            Assert.AreEqual(20, change.Quarters);
            Assert.AreEqual(0, change.Dimes);
            Assert.AreEqual(0, change.Nickels);

        }

        [TestMethod]
        public void CheckOneDollarAndFourtyCents()
        {
            change = new Change(1.40m);
            Assert.AreEqual(5, change.Quarters);
            Assert.AreEqual(1, change.Dimes);
            Assert.AreEqual(1, change.Nickels);

        }
    }
}
