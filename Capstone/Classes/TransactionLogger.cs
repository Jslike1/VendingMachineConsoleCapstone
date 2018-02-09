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
        string FilePath { get; set; }

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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RecordPurchase(string slot, string product, decimal amount, decimal finalBalance)
        {

            //Will include in the log attempts at purchasing items that threw an InsuffictientFundsException. The Balance will remain the same. Will display amount of money the customer came up short in parentheses.

            try
            {
                using (StreamWriter sr = new StreamWriter(FilePath, true))
                {
                    string itemNameAndSlot = $"{product} {slot}";
                sr.WriteLine($"{DateTime.Now.ToString().PadRight(23)} {itemNameAndSlot.PadRight(22)}{finalBalance.ToString("C").PadRight(10)}{(finalBalance - amount).ToString("C").PadRight(10)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
