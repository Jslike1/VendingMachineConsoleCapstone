using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes.Vending_Machine_Items
{
    public class CandyItem : VendingMachineItem
    {
        public CandyItem(string item, decimal price) : base(item, price)
        {
        }

        public override string Consume()
        {
            return "Munch Munch, Yum!";
        }
    }
}
