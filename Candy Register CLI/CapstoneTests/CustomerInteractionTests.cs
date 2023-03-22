using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class CustomerInteractionTests
    {
        CustomerInteraction sample = new CustomerInteraction();
        Inventory itemToBuy = new Inventory("CH", "C1", "Choco Brocko", 1.10m, true);
        int numOfItems = 2;
        decimal customerBalance = 100;

        [TestMethod]
        public void MakeChangeDispensesProperQuantityOfEachMoneyType()
        {
            // Arrange
            // using sample customer object above
            sample.AddBalance(96.15m);

            // Act
            string result = sample.MakeChange();

            // Assert
            Assert.AreEqual("4 Twenties, 1 Tens, 1 Fives, 1 Ones, 1 Dimes, 1 Nickels", result);
        }
        [TestMethod]
        public void SelectProductShouldAddItemToCart()
        {
            // Arrange
            // using sample customer object above


            // Act
            sample.SelectProduct(itemToBuy, numOfItems);
            bool doesContainItem = sample.Cart.ContainsKey(itemToBuy);

            // Assert
            Assert.AreEqual(true, doesContainItem);
        }

        [TestMethod]
        public void IsRichEnoughShouldBeTrueWhenCustomerHasEnoughMoney()
        {
            // Arrange
            // use sample customer object above

            // Act
            bool result = sample.IsRichEnough(itemToBuy, numOfItems, customerBalance);

            // Assert
            Assert.IsTrue(result);
        }

    }
}
