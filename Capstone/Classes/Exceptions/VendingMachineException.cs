using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes.Exceptions
{
    public abstract class VendingMachineException : Exception
    {
        public VendingMachineException()
        {
        }

        public VendingMachineException(string message) : base(message)
        {
        }

        public VendingMachineException(string message, Exception inner) : base(message, inner)
        {
        }


    }
}
