using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        private List<VendingMachineItem> items = new List<VendingMachineItem>();
        private string filePath = @"C:\VendingMachine";
        private string fileName = "vendingmachine.csv";

        public bool ReadFile()
        {
            bool result = true;
            try
            {
                string fullPath = Path.Combine(filePath, fileName);
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string nextString = sr.ReadLine();
                        string[] splitString = nextString.Split('|');

                        VendingMachineItem vendItem = new VendingMachineItem();

                        vendItem.typeNumber = splitString[0];
                        vendItem.itemName = splitString[1];
                        vendItem.itemPrice = Decimal.Parse(splitString[2]);
                        vendItem.itemQuantity = 5;

                        items.Add(vendItem);
                    }
                }
            }
            catch(Exception ex)
            {
                result = false;
            }

            return result;
        }

        public VendingMachineItem[] List()
        {
            return items.ToArray();
        }
    }
}
