using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes.Vending_Machine_Items
{
    public abstract class VendingMachineItem
    {
        public string ItemName { get; }
        public decimal Price { get; }

        public VendingMachineItem(string item, decimal price)
        {
            this.ItemName = item;
            this.Price = price;
        }

        public virtual string Consume()
        {
            return "";
        }
    }
}
