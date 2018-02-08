using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes.Vending_Machine_Items;
using System.IO;

namespace Capstone.Classes
{
    class FileReader
    {
        private string FilePath;

        FileReader(string filePath)
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

                        line = sr.ReadLine();
                        List<string> itemInfo = new List<string>(line.Split('|'));
                        key = itemInfo[0];
                        itemName = itemInfo[1];
                        price = decimal.Parse(itemInfo[2]);

                        if (key[0] == 'A')
                        {
                            result.Add(key, new ChipItem(itemName, price));
                        }
                        else if (key[0] == 'B')
                        {
                            result.Add(key, new CandyItem(itemName, price));
                        }
                        else if (key[0] == 'C')
                        {
                            result.Add(key, new BeverageItem(itemName, price));
                        }
                        else
                        {
                            result.Add(key, new GumItem(itemName, price));
                        }






                    }
                }
            }
            catch
            {

            }


            return result;
        }

        //private void AddVendingMachineItem(string key, string itemName, decimal price)
        //{



        //    if (key[0] == 'A')
        //    {
        //        result = new ChipItem(itemName, price);
        //    }
        //    else if(key[0] == 'B')
        //    {
        //        result = new CandyItem(itemName, price);
        //    }
        //    else if (key[0] == 'C')
        //    {
        //        result = new BeverageItem(itemName, price);
        //    }
        //    else
        //    {
        //        result = new GumItem(itemName, price);
        //    }



        //}
    }
}
