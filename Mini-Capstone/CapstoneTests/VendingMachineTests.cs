using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void ReadFileTest()
        {            
            VendingMachine vendingObject = new VendingMachine();
            bool result = vendingObject.ReadFile();
            Assert.AreEqual(true, result);
            //will fail if the file path or file name is changed
        }

        [TestMethod]
        public void MakeChangeTest()
        {
            VendingMachine vendingObject = new VendingMachine();
            vendingObject.Balance = 2;
            Assert.AreEqual(vendingObject.Balance, 2);
            vendingObject.MakeChange();
            Assert.AreEqual(vendingObject.Balance, 0);
            vendingObject.Balance = 5;
            Assert.AreEqual(vendingObject.Balance, 5);
            vendingObject.MakeChange();
            Assert.AreEqual(vendingObject.Balance, 0);
        }
    }
}
