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
        static TransactionLogger transactionLogger = new TransactionLogger("log.txt");

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
                        
                        DisplayItems(vendingMachine);
                        
                        
                    }
                    else if(number == 2)
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
            while (true)
            {

                
                Console.WriteLine();
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine();
                Console.WriteLine("(2) Select Product");
                Console.WriteLine();
                Console.WriteLine("(3) Finish Transaction");
                string userInput = Console.ReadLine();
                if(Int32.TryParse(userInput, out int number))
                {
                    if(number == 1)
                    {
                        TakeBill();
                    }
                }
            }

        }

        private void TakeBill()
        {
            while (true)
            {
                string userInput;
                Console.Write("What kind of bill will you feed? (1) (2) (5) (10): ");
                userInput = Console.ReadLine();
                if ((Int32.TryParse(userInput, out int number)) && (number == 1 || number == 2 || number == 5 || number == 10))
                {
                    vendingMachine.FeedMoney(number);
                    Console.WriteLine("Amount currently in vending machine: " + vendingMachine.Balance.ToString("C"));
                    Console.WriteLine();
                    transactionLogger.RecordDeposit(number, vendingMachine.Balance);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a valid choice");
                    Console.WriteLine();
                }
                
            }

        }

        private void DisplayItems(VendingMachine vendingMachine)
        {
            for (int i = 0; i < vendingMachine.Slots.Length; i++)
            {
                Console.WriteLine($"{vendingMachine.Slots[i]}:  " +
                    $"{vendingMachine.Inventory[vendingMachine.Slots[i]][0].ItemName.PadRight(20)}" +
                    $"{vendingMachine.Inventory[vendingMachine.Slots[i]][0].Price.ToString("C").PadLeft(10)}");
                
            }
            Console.WriteLine();
        }
    }



}
