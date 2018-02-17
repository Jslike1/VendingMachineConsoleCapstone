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

        private void WriteToFile(string message)
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(FilePath, true))
                {

                    sr.WriteLine(message);
                }
            }
            catch (Exception)
            {
                Console.WriteLine();
                Console.WriteLine(exceptionMessage);
                Freeze();
            }
        }


        public void RecordDeposit(decimal amount, decimal finalBalance)
        {
            string feedMoney = "FEED MONEY:";
            WriteToFile($"{DateTime.Now.ToString().PadRight(23)} {feedMoney.PadRight(22)}{amount.ToString("C").PadRight(10)}{finalBalance.ToString("C").PadRight(10)}");            
        }

        public void RecordPurchase(string slot, string product, decimal amount, decimal balance)
        {
            if (balance >= amount)
            {
                string itemNameAndSlot = $"{product} {slot}";
                WriteToFile($"{DateTime.Now.ToString().PadRight(23)} {itemNameAndSlot.PadRight(22)}{balance.ToString("C").PadRight(10)}{(balance - amount).ToString("C").PadRight(10)}");
            }          
        }

        public void RecordCompleteTransaction(decimal finalBalance)
        {
            string giveChange = "GIVECHANGE";
            string zeros = "$0.00";
            WriteToFile($"{DateTime.Now.ToString().PadRight(23)} {giveChange.PadRight(22)}{finalBalance.ToString("C").PadRight(10)}{zeros.PadRight(10)}");           
        }


        private void Freeze()
        {
            Console.WriteLine();
            Console.WriteLine("Press ENTER to Continue: ");
            Console.ReadLine();
        }
    }
}
