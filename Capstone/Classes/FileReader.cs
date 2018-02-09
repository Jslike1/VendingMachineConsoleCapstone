using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes.Vending_Machine_Items;
using System.IO;

namespace Capstone.Classes
{
    public class FileReader
    {
        private string FilePath;

        public FileReader(string filePath)
        {
            this.FilePath = filePath;
        }

        public Dictionary<string, List<VendingMachineItem>> GetInventory()
        {
            Dictionary<string, List<VendingMachineItem>> result = new Dictionary<string, List<VendingMachineItem>>();
            string line;
            string key;
            string itemName;
            decimal price;
            try
            {
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    while (!sr.EndOfStream)
                    {

                        List<VendingMachineItem> slotContents = new List<VendingMachineItem>();

                        line = sr.ReadLine();
                        List<string> itemInfo = new List<string>(line.Split('|'));
                        key = itemInfo[0];
                        itemName = itemInfo[1];
                        price = decimal.Parse(itemInfo[2]);

                        if (key[0] == 'A')
                        {
                            for (int i = 0; i < 5; i++)
                            {
                            slotContents.Add(new ChipItem(itemName, price));

                            }
                        }
                        else if (key[0] == 'B')
                        {
                            for (int i = 0; i < 5; i++)
                            {
                            slotContents.Add(new CandyItem(itemName, price));

                            }
                        }
                        else if (key[0] == 'C')
                        {
                            for (int i = 0; i < 5; i++)
                            {
                            slotContents.Add(new BeverageItem(itemName, price));

                            }
                        }
                        else
                        {
                            for (int i = 0; i < 5; i++)
                            {
                            slotContents.Add(new GumItem(itemName, price));
                            }
                        }
                        result.Add(key, slotContents);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
            return result;
        }

    }
}
