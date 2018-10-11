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
            catch (Exception ex)
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
            try
            {
                Console.WriteLine();
                Console.WriteLine("Please enter amount to deposit:\n($1, $2, $5, $10, $20)");
                int inputAmount = Int32.Parse(Console.ReadLine());
                switch (inputAmount)
                {
                    case 1:
                    case 2:
                    case 5:
                    case 10:
                    case 20:
                        Balance += inputAmount;
                        Console.WriteLine();
                        Console.WriteLine($"Amount deposited: ${inputAmount}");

                        string logFilePath = @"C:\VendingMachine";
                        string logFileName = "TransactionLog.csv";
                        string logFullPath = Path.Combine(logFilePath, logFileName);
                        using (StreamWriter sw = new StreamWriter(logFullPath, true))
                        {
                            string outputString = $"{DateTime.UtcNow}| FEED MONEY |${inputAmount}|${Balance}";
                            sw.WriteLine(outputString);
                        }
                        break;

                    default:
                        Console.WriteLine("Please enter a valid amount.");
                        Console.WriteLine();
                        feedMoney();
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("That isn't even a number. Try again.");
                Console.WriteLine();
                feedMoney();
            }
        }

        public void Vend(string selection)
        {
            UserInterface userInterface = new UserInterface();
            foreach (VendingMachineItem item in items)
            {
                try
                {
                    if (selection.ToUpper() == item.typeNumber)
                    {
                        if (item.itemQuantity == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("SOLD OUT");
                            return;
                        }
                        if (Balance < item.itemPrice)
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

                            string logFilePath = @"C:\VendingMachine";
                            string logFileName = "TransactionLog.csv";
                            string logFullPath = Path.Combine(logFilePath, logFileName);
                            using (StreamWriter sw = new StreamWriter(logFullPath, true))
                            {
                                string outputString = $"{DateTime.UtcNow}|{item.itemName}|{item.typeNumber}|${Balance + item.itemPrice}|${Balance}";
                                sw.WriteLine(outputString);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("NO SUCH ITEM EXISTS; PLEASE MAKE A VALID CHOICE!!!");
                    Console.WriteLine();
                    return;
                }
            }

        }

        public void MakeChange()
        {
            decimal beginningBalance = Balance;
            decimal qt = 0;
            decimal dm = 0;
            decimal nk = 0;

            qt = Balance / .25M;
            Balance %= .25M;
            dm = Balance / .10M;
            Balance %= .10M;
            nk = Balance / .05M;
            Balance %= .05M;

            Console.WriteLine($"Your change is {(int)qt} quarters, {(int)dm} dimes, and {(int)nk} nickels.");

            string logFilePath = @"C:\VendingMachine";
            string logFileName = "TransactionLog.csv";
            string logFullPath = Path.Combine(logFilePath, logFileName);
            using (StreamWriter sw = new StreamWriter(logFullPath, true))
            {
                string outputString = $"{DateTime.UtcNow}| GIVE CHANGE |${beginningBalance}|${Balance}";
                sw.WriteLine(outputString);
            }
        }
    }
}
