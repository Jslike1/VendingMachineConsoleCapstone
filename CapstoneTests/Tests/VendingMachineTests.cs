using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests.Tests
{
    [TestClass]
    public class VendingMachineTests
    {
        VendingMachine vendingMachine;

        [TestInitialize]
        public void Initialize()
        {
            vendingMachine = new VendingMachine();
        }

        [TestMethod]
        public void PurchaseRemovesOneItem()
        {
            vendingMachine.Purchase()
        }
    }
}
