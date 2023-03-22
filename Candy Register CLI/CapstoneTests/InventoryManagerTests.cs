using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class InventoryManagerTests
    {
        [TestMethod]
        public void InventoryStockLoadsProperly()
        {
            //Arrange
            InventoryManager sample = new InventoryManager();


            //Act
            List<Inventory> Test = sample.Load();


            //Assert
            Assert.AreEqual("Snuckers Bar", Test[0].Name);

        }
        [TestMethod]
        public void IsInStockShouldReturnTrueWhenItemIsInStock()
        {
            // Arrange
            InventoryManager test = new InventoryManager();
            Inventory itemToBuy = new Inventory("CH", "C1", "Choco Brocko", 1.10m, true);
            int numOfItems = 2;

            // Act
            bool result = test.IsInStock(itemToBuy, numOfItems);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void FindIDShouldReturnNullWhenItemDoesNotExist()
        {
            // Arrange
            InventoryManager forFun = new InventoryManager();

            // Act

            Inventory item = forFun.FindID("G6");

            // Assert
            Assert.IsNull(item);
        }
    }
    
}
