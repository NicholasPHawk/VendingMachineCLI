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
            bool done = false;
            while (!done)
            {
                Console.WriteLine("(1) Display Vending Machine Items\n(2) Purchase\n(3) End");
                int interfaceInput = Int32.Parse(Console.ReadLine());
                
                switch (interfaceInput)
                {
                    case 1:
                        vendingMachine.ReadFile();
                        DisplayVendingMachine();
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                    case 2:
                        break;

                    case 3:
                        done = true;
                        break;
                }
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
