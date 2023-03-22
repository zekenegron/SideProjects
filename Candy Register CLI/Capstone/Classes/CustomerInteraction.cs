using System;
using System.Collections.Generic;
using System.Text;
using Capstone;

namespace Capstone.Classes
{
    public class CustomerInteraction
    {
        /// <summary>
        /// This tracks the amount of money the customer currently has to spend
        /// </summary>
        public decimal CustomerBalance { get; private set; }
        /// <summary>
        /// This tracks the purchases that a Customer has made
        /// </summary>
        public Dictionary<Inventory, int> Cart { get; private set; } = new Dictionary<Inventory, int>();

        public void AddBalance(decimal amountToAdd)
        {
            CustomerBalance += amountToAdd;
        }

        /// <summary>
        /// This executes a purchase for a Customer
        /// </summary>
        /// <param name="itemToBuy">This is the candy they are purchasing</param>
        /// <param name="numOfItems">This is the quantity of the specific candy item being purchased</param>
        public void SelectProduct(Inventory itemToBuy, int numOfItems)
        {
            CustomerBalance -= itemToBuy.Price * numOfItems;
            itemToBuy.Quantity -= numOfItems;
            Cart[itemToBuy] = numOfItems;
        }

        /// <summary>
        /// This calculates the change given after a customer completes a sale
        /// </summary>
        /// <returns></returns>
        public string MakeChange()
        {
            decimal hold100Balance = CustomerBalance * 100;
            int ChangeBalance = (int)(hold100Balance);

            const int nickel = 5;
            const int dime = 10;
            const int quarter = 25;
            const int oneDollar = 100;
            const int fiveDollar = 500;
            const int tennerDollar = 1000;
            const int twentyBigOnes = 2000;

            string changeString = "";

            int remainingBalance = 0;

            
            int twentyChange = ChangeBalance / twentyBigOnes;
            remainingBalance = ChangeBalance % twentyBigOnes;
            if( twentyChange > 0)
            {
                changeString += $"{twentyChange} Twenties, ";
            }

            
            int tenChange = remainingBalance / tennerDollar;
            remainingBalance %= tennerDollar;
            if (tenChange > 0)
            {
                changeString += $"{tenChange} Tens, ";
            }

            
            int fiveChange = remainingBalance / fiveDollar;
            remainingBalance %= fiveDollar;
            if (fiveChange > 0)
            {
                changeString += $"{fiveChange} Fives, ";
            }

            int oneChange = remainingBalance / oneDollar;
            remainingBalance %= oneDollar;
            if (oneChange > 0)
            {
                changeString += $"{oneChange} Ones, ";
            }

            
            int quarterChange = remainingBalance / quarter;
            remainingBalance %= quarter;
            if (quarterChange > 0)
            {
                changeString += $"{quarterChange} Quarters, ";
            }

            int dimeChange = remainingBalance / dime;
            remainingBalance %= dime;
            if (dimeChange > 0)
            {
                changeString += $"{dimeChange} Dimes, ";
            }

            
            int nickelChange = remainingBalance / nickel;
            remainingBalance %= nickel;
            if (nickelChange > 0)
            {
                changeString += $"{nickelChange} Nickels, ";
            }

            string returnString = changeString.Remove(changeString.Length - 2);

            CustomerBalance = 0;

            return returnString;
        }

        public bool IsRichEnough(Inventory itemToCheck, int numOfItems, decimal customerBalance)
        {
            decimal cost = itemToCheck.Price * numOfItems;
            if (cost < customerBalance)
            {
                return true;
            }
            return false;
        }

    }
}
