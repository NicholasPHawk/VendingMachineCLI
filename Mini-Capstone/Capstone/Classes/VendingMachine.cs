using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public decimal Balance { get; set; }

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

        public void feedMoney()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter amount to deposit:\n($1, $2, $5, $10, $20)");
            int inputAmount = Int32.Parse(Console.ReadLine());
            switch (inputAmount)
            {
                case 1:
                    Balance += inputAmount;
                    Console.WriteLine();
                    Console.WriteLine($"Amount deposited: ${inputAmount}");
                    break;

                case 2:
                    Balance += inputAmount;
                    Console.WriteLine();
                    Console.WriteLine($"Amount deposited: ${inputAmount}");
                    break;

                case 5:
                    Balance += inputAmount;
                    Console.WriteLine();
                    Console.WriteLine($"Amount deposited: ${inputAmount}");
                    break;

                case 10:
                    Balance += inputAmount;
                    Console.WriteLine();
                    Console.WriteLine($"Amount deposited: ${inputAmount}");
                    break;

                case 20:
                    Balance += inputAmount;
                    Console.WriteLine();
                    Console.WriteLine($"Amount deposited: ${inputAmount}");
                    break;

                default:
                    Console.WriteLine("Please enter a valid amount.");
                    Console.WriteLine();
                    feedMoney();
                    break;
            }
        }

        public void Vend(string selection)
        {
            foreach (VendingMachineItem item in items)
            {
                if (selection.ToUpper() == item.typeNumber)
                {
                    if (item.itemQuantity == 0)
                    {
                        UserInterface userInterface = new UserInterface();
                        Console.WriteLine();
                        Console.WriteLine("SOLD OUT");
                        userInterface.vendingMenu();
                    }
                    else if (Balance < item.itemPrice)
                    {
                        Console.WriteLine("NOT ENOUGH MONEY, PLEASE INSERT MORE AND TRY AGAIN");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Dispensing: {item.itemName}");

                        if (item.typeNumber.Contains('A'))
                        {
                            Console.WriteLine("Crunch Crunch, Yum!");
                        }
                        else if (item.typeNumber.Contains('B'))
                        {
                            Console.WriteLine("Munch Munch, Yum!");
                        }
                        else if (item.typeNumber.Contains('C'))
                        {
                            Console.WriteLine("Glug Glug, Yum!");
                        }
                        else if (item.typeNumber.Contains('D'))
                        {
                            Console.WriteLine("Chew Chew, Yum!");
                        }
                        Console.WriteLine();
                        item.itemQuantity -= 1;
                        Balance -= item.itemPrice;
                    }
                }
            }
        }
    }
}
