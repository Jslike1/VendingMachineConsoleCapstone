using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests.Tests
{
    [TestClass]
    public class VendingMachineTests
    {
        VendingMachine vendingMachine;
        string[] keys;

        [TestInitialize]
        public void Initialize()
        {
            
            vendingMachine = new VendingMachine();
            
            keys = new string[vendingMachine.Inventory.Keys.Count];
            int count = 0;

            foreach (string key in vendingMachine.Inventory.Keys)
            {
                keys[count] = key;
                count++;
            }

        }


        [TestMethod]
        public void BalanceEqualsMoneyFed()
        {
            vendingMachine.FeedMoney(100);
            Assert.AreEqual(100, vendingMachine.Balance);

            vendingMachine.FeedMoney(100);
            Assert.AreEqual(200, vendingMachine.Balance);
        }

        [TestMethod]
        public void PurchaseRemovesOneItem()
        {
            vendingMachine.FeedMoney(100);
            vendingMachine.Purchase(keys[0]);
            Assert.AreEqual(4, vendingMachine.Inventory[keys[0]].Count);
        }

        [TestMethod]
        public void PurchaseRemovesMoney()
        {
            vendingMachine.FeedMoney(100);
            vendingMachine.Purchase(keys[0]);
            var amountRemoved = vendingMachine.Inventory[keys[0]][0].Price;
            Assert.AreEqual(100 - amountRemoved, vendingMachine.Balance);
        }

        [TestMethod]
        public void ReturnChangeReturnsChangeObject()
        {
            Assert.IsTrue(vendingMachine.ReturnChange() is Change);
        }




    }
}
