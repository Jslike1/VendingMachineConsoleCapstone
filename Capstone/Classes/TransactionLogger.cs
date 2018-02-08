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
                using (StreamWriter sr = new StreamWriter("Log.txt", true))
                {
                    sr.WriteLine($"{DateTime.Today} {DateTime.Now} FEED MONEY: ${amount}    ${finalBalance}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RecordPurchase(string slot, string product, decimal amount, decimal finalBalance)
        {
            try
            {
                using (StreamWriter sr = new StreamWriter("Log.txt", true))
                {
                    sr.WriteLine($"{DateTime.Today} {DateTime.Now} {product} {slot} ${amount}    ${finalBalance}");
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
                using (StreamWriter sr = new StreamWriter("Log.txt", true))
                {
                    sr.WriteLine($"{DateTime.Today} {DateTime.Now} GIVECHANGE ${finalBalance}    $0.00");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
