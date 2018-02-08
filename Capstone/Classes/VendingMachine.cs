using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes.Vending_Machine_Items;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public Dictionary<string, List<VendingMachineItem>> Inventory { get; set; }

        public decimal Balance { get; private set; }

        public string[] Slots
        {
            get
            {
                string[] slots = new string[0];

                return slots;

            }

        }

        public void FeedMoney(int dollars)
        {
            Balance += dollars;
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

        public VendingMachine(Dictionary<string, List<VendingMachineItem>> startingInventory)
        {
            foreach(string key in startingInventory.Keys)
            {
                Inventory[key] = startingInventory[key];
            }
        }

    }
}
