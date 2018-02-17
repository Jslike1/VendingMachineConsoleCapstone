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
        private const int DefaultQuantity = 5;
        private const int SlotId = 0;
        private const int Name = 1;
        private const int Cost = 2;

        public FileReader(string filePath)
        {
            this.FilePath = filePath;
        }

        public Dictionary<string, List<VendingMachineItem>> GetInventory()
        {
            Dictionary<string, List<VendingMachineItem>> result = new Dictionary<string, List<VendingMachineItem>>();
            string line;
            try
            {
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();

                        var newSlot = CreateInventoryItem(line);    
                        
                        result.Add(newSlot.Key, newSlot.Value);
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

        private KeyValuePair<string, List<VendingMachineItem>> CreateInventoryItem(string line)
        {            
            List<VendingMachineItem> slotContents = new List<VendingMachineItem>();
            List<string> itemInfo = new List<string>(line.Split('|'));

            string key = itemInfo[SlotId];
            string itemName = itemInfo[Name];
            decimal price = decimal.Parse(itemInfo[Cost]);

            if (key[0] == 'A')
            {
                for (int i = 0; i < DefaultQuantity; i++)
                {
                    slotContents.Add(new ChipItem(itemName, price));
                }
            }
            else if (key[0] == 'B')
            {
                for (int i = 0; i < DefaultQuantity; i++)
                {
                    slotContents.Add(new CandyItem(itemName, price));
                }
            }
            else if (key[0] == 'C')
            {
                for (int i = 0; i < DefaultQuantity; i++)
                {
                    slotContents.Add(new BeverageItem(itemName, price));
                }
            }
            else
            {
                for (int i = 0; i < DefaultQuantity; i++)
                {
                    slotContents.Add(new GumItem(itemName, price));
                }
            }

            KeyValuePair<string, List<VendingMachineItem>> kvp = new KeyValuePair<string, List<VendingMachineItem>>(key, slotContents);

            return kvp;
        }
    }
}
