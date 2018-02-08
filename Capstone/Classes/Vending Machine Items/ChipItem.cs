using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes.Vending_Machine_Items
{
    public class ChipItem : VendingMachineItem

    {
        public ChipItem(string item, decimal price) : base(item, price)
        {
        }

        public override string Consume()
        {
            throw new NotImplementedException();
        }
    }
}
