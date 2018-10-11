using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {
        private VendingMachine vendingMachine = new VendingMachine();

        public void RunInterface()
        {
            vendingMachine.ReadFile();
            bool done = false;
            while (!done)
            {
                Console.WriteLine("(1) Display Vending Machine Items\n(2) Purchase\n(3) End");
                int interfaceInput = Int32.Parse(Console.ReadLine());

                switch (interfaceInput)
                {
                    case 1:
                        DisplayVendingMachine();
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                    case 2:
                        vendingMenu();
                        break;

                    case 3:
                        done = true;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid choice.");
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                }
            }

        }

        public void vendingMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"(1) Feed Money\n(2) Select Product\n(3) Finish Transaction\nCurrent Balance: ${vendingMachine.Balance}");
            int vendingInput = Int32.Parse(Console.ReadLine());

            switch (vendingInput)
            {
                case 1:
                    vendingMachine.feedMoney();
                    vendingMenu();
                    break;

                case 2:
                    DisplayVendingMachine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Enter selection:");
                    string selection = Console.ReadLine();
                    vendingMachine.Vend(selection);
                    vendingMenu();
                    break;

                case 3:
                    //vendingMachine.MakeChange();
                    Console.WriteLine();
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine("Please enter a valid choice.");
                    vendingMenu();
                    break;
            }
        }

        private void DisplayVendingMachine()
        {
            VendingMachineItem[] result = vendingMachine.List();
            for (int i = 0; i < 16; i++)
            {
                Console.WriteLine(result[i].ToString());
            }
        }
    }
}
