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
                foreach (string key in Inventory.Keys)
                {
                    slots[counter] = key;
                    counter++;
                }
                return slots;

            }

        }

        public bool IsValidSlot(string slot)
        {
            return Inventory.ContainsKey(slot);
        }

        public void FeedMoney(int dollars)
        {
            Balance += (decimal)dollars;
        }

        public bool CheckQuantityRemaining(string slot)
        {
            return Inventory[slot].Count > 0;
        }

        public VendingMachineItem Purchase(string slot)
        {
            if (!Inventory.ContainsKey(slot))
            {
                throw new InvalidSlotException();
            }

            if (Inventory[slot].Count == 0)
            {
                throw new OutOfStockException();
            }

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
            this.Inventory = fileReader.GetInventory();
        }

    }
}
