using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachineItem
    {
        public string typeNumber { get; set; }
        public string itemName { get; set; }
        public decimal itemPrice { get; set; }
        public int itemQuantity { get; set; }

        public override string ToString()
        {
            return $"{typeNumber} {itemName}  {itemPrice}  {itemQuantity}";
        }

        //not sure what output should look like yet
    }
}
