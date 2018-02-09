using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using Capstone.Classes.Vending_Machine_Items;
using System.Collections.Generic;

namespace CapstoneTests.Tests
{
    [TestClass]
    public class FileReaderTests
    {
        FileReader fileReader;

        [TestInitialize]
        public void Initialize()
        {
            fileReader = new FileReader("vendingmachine.csv");
        }


        [TestMethod]
        public void GetInventoryReturnsADictionary()
        {
            
            Assert.IsTrue(fileReader.GetInventory() is Dictionary<string, List<VendingMachineItem>>);
                
        }

       
    }
}
