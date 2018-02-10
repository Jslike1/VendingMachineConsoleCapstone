using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    class TransactionLogger
    {
        private string FilePath { get; set; }
        private string exceptionMessage = "Error writing log.txt; check to make sure file or folder is not read-only.";

        public TransactionLogger(string filePath)
        {
            FilePath = filePath;
        }

        public void RecordDeposit(decimal amount, decimal finalBalance)
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(FilePath, true))
                {
                    string feedMoney = "FEED MONEY:";
                    sr.WriteLine($"{DateTime.Now.ToString().PadRight(23)} {feedMoney.PadRight(22)}{amount.ToString("C").PadRight(10)}{finalBalance.ToString("C").PadRight(10)}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine();
                Console.WriteLine(exceptionMessage);
                Freeze();
            }
        }

        public void RecordPurchase(string slot, string product, decimal amount, decimal balance)
        {
            if (balance >= amount)
            {
                try
                {
                    using (StreamWriter sr = new StreamWriter(FilePath, true))
                    {
                        string itemNameAndSlot = $"{product} {slot}";
                        sr.WriteLine($"{DateTime.Now.ToString().PadRight(23)} {itemNameAndSlot.PadRight(22)}{balance.ToString("C").PadRight(10)}{(balance - amount).ToString("C").PadRight(10)}");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine();
                    Console.WriteLine(exceptionMessage);
                    Freeze();
                }
            }
        }

        public void RecordCompleteTransaction(decimal finalBalance)
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(FilePath, true))
                {
                    string giveChange = "GIVECHANGE";
                    string zeros = "$0.00";
                    sr.WriteLine($"{DateTime.Now.ToString().PadRight(23)} {giveChange.PadRight(22)}{finalBalance.ToString("C").PadRight(10)}{zeros.PadRight(10)}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine();
                Console.WriteLine(exceptionMessage);
                Freeze();
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
