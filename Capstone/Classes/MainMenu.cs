using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes.Vending_Machine_Items;
using Capstone.Classes.Exceptions;

namespace Capstone.Classes
{
    public class MainMenu
    {

        static VendingMachine vendingMachine = new VendingMachine();
        static TransactionLogger transactionLogger = new TransactionLogger("log.txt");
        static List<VendingMachineItem> shoppingCart = new List<VendingMachineItem>();
        public static string validInputPrompt = "Please enter a valid input... ";
        public static string balanceMessage = $"Amount currently in vending machine: ";

        public void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Menu:");
                Console.WriteLine("(1) Display Vending Machine Contents");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(3) Leave Vending Machine");
                Console.WriteLine();
                string userInput = Console.ReadLine();
                if (Int32.TryParse(userInput, out int number))
                {
                    
                    if (number == 1)
                    {

                        DisplayItems(vendingMachine);
                        Freeze();

                    }
                    else if (number == 2)
                    {
                        PurchaseItem(vendingMachine);
                    }
                    else if (number == 3)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"{validInputPrompt} (1 or 2)");
                        Console.WriteLine();
                        userInput = "";
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"{validInputPrompt} (1 or 2)");
                    Console.WriteLine();
                }
            }
        }

        private void PurchaseItem(VendingMachine vendingMachine)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Menu:");
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine($"{balanceMessage} {vendingMachine.Balance.ToString("C")}");
                Console.WriteLine();
                string userInput = Console.ReadLine();
                if (Int32.TryParse(userInput, out int number))
                {
                    if (number == 1)
                    {
                        TakeBill();
                    }
                    if (number == 2)
                    {
                        SelectProduct();
                    }
                    if (number == 3)
                    {
                        FinishTransaction();
                        break;
                    }
                }
            }
        }

        private void FinishTransaction()
        {
            Console.WriteLine();
            Change change = vendingMachine.ReturnChange();
            Console.WriteLine($"You receive {change.Quarters} quarters, {change.Dimes} dimes, and {change.Nickels} nickels. ");
            Console.WriteLine();
            Console.WriteLine($"{balanceMessage} {vendingMachine.Balance.ToString("C")}");
            Console.WriteLine();
            if (shoppingCart.Count != 0)
            {
                Console.WriteLine("Time to eat your snacks...");
                Console.WriteLine();
                foreach (VendingMachineItem snack in shoppingCart)
                {
                    Console.WriteLine(snack.Consume());
                    
                }
                shoppingCart = new List<VendingMachineItem>();
                Console.WriteLine();
            }
            Freeze();
        }


        private void SelectProduct()
        {
            while (true)
            {
                Console.Clear();
                string userInput;
                DisplayItems(vendingMachine);
                Console.WriteLine();
                Console.WriteLine($"{balanceMessage} {vendingMachine.Balance.ToString("C")}");
                Console.WriteLine("Which product do you want to purchase? (Ex: A4, C3...) Or Press ENTER to Finish: ");
                userInput = Console.ReadLine().ToUpper();
                if (userInput == "")
                {
                    break;
                }
                if (vendingMachine.Inventory.ContainsKey(userInput))
                {
                    try
                    {
                        vendingMachine.CheckQuantityRemaining(userInput);
                        transactionLogger.RecordPurchase(userInput, vendingMachine.Inventory[userInput][0].ItemName, vendingMachine.Inventory[userInput][0].Price, vendingMachine.Balance);

                        Console.WriteLine();

                        shoppingCart.Add(vendingMachine.Purchase(userInput));

                        Console.WriteLine($"Dispensing {shoppingCart[shoppingCart.Count - 1].ItemName}");
                        Console.WriteLine();
                        Console.WriteLine($"{balanceMessage} {vendingMachine.Balance.ToString("C")}");
                    }
                    catch (OutOfStockException)
                    {
                        Console.WriteLine();
                        Console.WriteLine("That item it out of stock...");
                        Console.WriteLine();
                    }
                    catch (InsufficientFundsException)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You did not feed enough money to purchase that item.");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(validInputPrompt);
                }
                Freeze();

            }
        }

        private void TakeBill()
        {
            while (true)
            {
                Console.Clear();

                string userInput;
                Console.WriteLine();
                Console.WriteLine("What kind of bill will you feed? ( 1, 2, 5, 10 ) OR Press ENTER to Finish: ");
                Console.WriteLine($"{balanceMessage} {vendingMachine.Balance.ToString("C")}");
                userInput = Console.ReadLine();
                if (userInput == "")
                {
                    break;
                }
                if ((Int32.TryParse(userInput, out int number)) && (number == 1 || number == 2 || number == 5 || number == 10))
                {
                    vendingMachine.FeedMoney(number);
                    Console.WriteLine();
                    transactionLogger.RecordDeposit(number, vendingMachine.Balance);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(validInputPrompt);
                    Console.WriteLine();
                    Freeze();
                }
            }
        }

        private void DisplayItems(VendingMachine vendingMachine)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Vending Machine Contents:");
            Console.WriteLine();

            for (int i = 0; i < vendingMachine.Slots.Length; i++)
            {
                if (vendingMachine.Inventory[vendingMachine.Slots[i]].Count > 0)
                {
                    Console.WriteLine($"{vendingMachine.Slots[i]}:  " +
                        $"{vendingMachine.Inventory[vendingMachine.Slots[i]][0].ItemName.PadRight(20)}" +
                        $"{vendingMachine.Inventory[vendingMachine.Slots[i]][0].Price.ToString("C").PadLeft(10)}");
                }
                else
                {
                    Console.WriteLine($"{vendingMachine.Slots[i]}:  OUT OF STOCK");
                }
            }
        }

        private void Freeze()
        {
                Console.WriteLine();
                Console.WriteLine("Press ENTER to Continue: ");
                Console.ReadLine();          
        }
    }



}
