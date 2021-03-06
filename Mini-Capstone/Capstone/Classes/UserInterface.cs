﻿using System;
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
                done = MainMenu();
            }
        }


        public bool MainMenu()
        {
            try
            {
                Console.WriteLine("(1) Display Vending Machine Items\n(2) Purchase\n(3) End");
                int interfaceInput = Int32.Parse(Console.ReadLine());

                switch (interfaceInput)
                {
                    case 1:
                        DisplayVendingMachine();
                        Console.WriteLine();
                        Console.WriteLine();
                        return true;


                    case 2:
                        VendingMenu();
                        return true;

                    case 3:
                        return false;

                    default:
                        Console.WriteLine("Please enter a valid choice.");
                        Console.WriteLine();
                        Console.WriteLine();
                        return true;
                }
            }
            catch
            {
                Console.WriteLine("Please enter a valid choice.");
                return true;
            }
        }

        public void VendingMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"(1) Feed Money\n(2) Select Product\n(3) Finish Transaction\nCurrent Balance: ${vendingMachine.Balance}");
            try
            {
                int vendingInput = Int32.Parse(Console.ReadLine());

                switch (vendingInput)
                {
                    case 1:
                        vendingMachine.FeedMoney();
                        VendingMenu();
                        break;

                    case 2:
                        DisplayVendingMachine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Enter selection:");
                        string selection = Console.ReadLine();
                        vendingMachine.Vend(selection);
                        VendingMenu();
                        break;

                    case 3:
                        vendingMachine.MakeChange();
                        Console.WriteLine();
                        Console.WriteLine();
                        MainMenu();
                        break;

                    default:
                        Console.WriteLine("Please enter a valid choice.");
                        VendingMenu();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please enter a valid choice.");
                VendingMenu();
            }
        }

        private void DisplayVendingMachine()
        {
            VendingMachineItem[] result = vendingMachine.List();
            foreach (VendingMachineItem item in result)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
}
