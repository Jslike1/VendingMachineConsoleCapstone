using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes.Vending_Machine_Items;
using Capstone.Classes.Exceptions;

namespace Capstone.Classes
{

    public class VendingMachine
    {
        public FileReader fileReader = new FileReader("vendingmachine.csv"); 

        public Dictionary<string, List<VendingMachineItem>> Inventory { get; set; }

        public decimal Balance { get; private set; }

        public string[] Slots
        {
            get
            {
                string[] slots = new string[Inventory.Count];
                int counter = 0;
                foreach(string key in Inventory.Keys)
                {
                    slots[counter] = key;
                    counter++;
                }
                return slots;

            }

        }

        public void FeedMoney(int dollars)
        {
            Balance += (decimal)dollars;
        }

        public VendingMachineItem GetItemAtSlot(string slot)
        {
            
            VendingMachineItem tempItem = Inventory[slot][0];
            return tempItem;
        }

        public int GetQuantityRemaining(string slot)
        {

            return Inventory[slot].Count;
        }

        public VendingMachineItem Purchase(string slot)
        {
            if (Balance < Inventory[slot][0].Price)
            {
                throw new InsufficientFundsException();
            }
            VendingMachineItem returnItem;

                Balance -= Inventory[slot][0].Price;
                returnItem = Inventory[slot][0];
                Inventory[slot].RemoveAt(0);

                return returnItem;
                
           

        }

        public Change ReturnChange()
        {
            Change change = new Change(Balance);
            Balance = 0;
            return change;
            
        }

        public VendingMachine()
        {
            //Dictionary<string, List<VendingMachineItem>> startingInventory
            //foreach(string key in startingInventory.Keys)
            //{
            //    Inventory[key] = startingInventory[key];
            //}
            this.Inventory = fileReader.GetInventory();

        }

    }
}
