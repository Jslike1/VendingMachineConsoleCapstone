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
        public Dictionary<string, VendingMachineItem> Inventory { get; set; }

        public decimal Balance { get; private set; }

        public string[] Slots { get; }

    }
}
