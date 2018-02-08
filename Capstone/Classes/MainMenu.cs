using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class MainMenu
    {

        static VendingMachine vendingMachine = new VendingMachine();


        public void DisplayMenu()
        {



            while(true)
            {
                Console.WriteLine("(1) Display Vending Machine Contents");
                Console.WriteLine();
                Console.WriteLine("(2) Purchase");
                string userInput = Console.ReadLine();
                if (Int32.TryParse(userInput, out int number))
                {
                    if(number == 1)
                    {
                        Console.WriteLine("Enter DisplayItems subclass");
                        DisplayItems(vendingMachine);
                        break;
                        
                    }
                    if(number == 2)
                    {
                        Console.WriteLine("PurchaseItems");
                        PurchaseItem(vendingMachine);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please enter a valid input (1 or 2)");
                        Console.WriteLine();
                    }

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid input (1 or 2)");
                    Console.WriteLine();
                }
            }
        }

        private void PurchaseItem(VendingMachine vendingMachine)
        {
            throw new NotImplementedException();
        }

        private void DisplayItems(VendingMachine vendingMachine)
        {
            throw new NotImplementedException();
        }
    }



}
