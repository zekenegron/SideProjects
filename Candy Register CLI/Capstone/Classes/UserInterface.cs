using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class is responsible for displaying data to the user and getting input from the user
    /// </summary>
    /// <remarks>
    /// All Console statements belong in this class.
    /// NO Console statements should be in any other class.
    /// </remarks>
    public sealed class UserInterface
    {

        private InventoryManager invStore = new InventoryManager();
        private CustomerInteraction customer = new CustomerInteraction();
        private Logs log = new Logs();

        /// <summary>
        /// Provides all communication with human user.
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Welcome to Candy Shop CheckOut!");
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            Console.WriteLine();

            bool done = false;

            while (!done)
            {
                Console.WriteLine();
                Console.WriteLine("**************************");
                Console.WriteLine("******* Main Menu ********");
                Console.WriteLine("**************************");
                Console.WriteLine();
                Console.WriteLine("1) Show Inventory");
                Console.WriteLine("2) Make Sale");
                Console.WriteLine("3) Quit!");
                Console.WriteLine();

                string custInput = Console.ReadLine();


                if (custInput == "1")
                {
                    ShowInventory();
                }
                else if (custInput == "2")
                {
                    ShowMakeSaleSubMenu();
                }
                else if (custInput == "3")
                {
                    done = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input, please try again!");
                }

            }
        }
        private void ShowMakeSaleSubMenu()
        {
            bool done = false;

            while (!done)
            {
                Console.WriteLine();
                Console.WriteLine("**************************");
                Console.WriteLine("***** Make Sale Menu *****");
                Console.WriteLine("**************************");
                Console.WriteLine();
                Console.WriteLine("1) Take Money");
                Console.WriteLine("2) Select Product");
                Console.WriteLine("3) Complete Sale");
                Console.WriteLine();
                Console.WriteLine("Current Account Balance: $" + customer.CustomerBalance);
                Console.WriteLine();

                string custInput = Console.ReadLine();

                if (custInput == "1")
                {
                    try
                    {
                        TakeMoney();
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine("ERROR: You must input a whole number silly goose!");
                    }
                }
                else if (custInput == "2")
                {
                    ShowInventory();
                    Console.WriteLine();
                    Console.WriteLine("Select Products to add to Cart by typing in ID:");
                    string inputId = Console.ReadLine();

                    Console.WriteLine();
                    Console.WriteLine("How many would you like?");
                    int numOfItems = int.Parse(Console.ReadLine());

                    Inventory itemToBuy = invStore.FindID(inputId);
                    if (itemToBuy == null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("ERROR: We don't have that item :c");
                    }
                    else if (itemToBuy.Quantity == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("ERROR: We are SOLD OUT!");
                    }
                    else if (!invStore.IsInStock(itemToBuy, numOfItems))
                    {
                        Console.WriteLine();
                        Console.WriteLine("ERROR: We don't have enough in stock :(");
                    }
                    else if (!customer.IsRichEnough(itemToBuy, numOfItems, customer.CustomerBalance))
                    {
                        Console.WriteLine();
                        Console.WriteLine("ERROR: You don't have enough money :(");
                    }
                    else
                    {
                        customer.SelectProduct(itemToBuy, numOfItems);
                        log.LogItemPurchased(itemToBuy, numOfItems, customer.CustomerBalance);
                    }

                }
                else if (custInput == "3")
                {
                    CompleteSale();
                    done = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input, please try again!");
                }

            }

        }

        /// <summary>
        /// This method generates a receipt, logs the purchase, empties the customer balance, dispenses change and returns the user back to the main menu
        /// </summary>
        public void CompleteSale()
        {
            decimal total = 0;

            Console.WriteLine();
            Console.WriteLine("**************************");
            Console.WriteLine("********* Receipt ********");
            Console.WriteLine("**************************");
            Console.WriteLine();

            foreach (KeyValuePair<Inventory, int> kvp in customer.Cart)
            {
                decimal totalPrice = kvp.Key.Price * kvp.Value;
                Console.WriteLine($"{kvp.Value.ToString().PadRight(4)}{kvp.Key.Name.PadRight(20)}{kvp.Key.Descrip.PadRight(25)}{kvp.Key.Price.ToString("c").PadRight(8)}{totalPrice.ToString("c").PadRight(8)}");
                total += totalPrice;
            }

            Console.WriteLine();
            Console.WriteLine("Total: " + total.ToString("c"));
            Console.WriteLine();

            Console.WriteLine("Change: " + customer.CustomerBalance.ToString("c"));

            log.LogChangeGiven(customer.CustomerBalance);
            string changeString = customer.MakeChange();
            Console.WriteLine();
            Console.WriteLine(changeString);
        }

        /// <summary>
        /// This method allows a Customer to add to their balance in up to $100 increments (whole numbers only) with a max balance of $1000
        /// </summary>
        public void TakeMoney()
        {
            Console.WriteLine();
            Console.WriteLine("How much money would you like to add to your balance? (Whole dollars up to $100 only)");
            decimal amountToAddInput = decimal.Parse(Console.ReadLine());

            bool under1000 = (customer.CustomerBalance + amountToAddInput) <= 1000;

            if (amountToAddInput <= 100 && amountToAddInput > 0 && under1000)
            {
                customer.AddBalance(amountToAddInput);
                log.LogMoneyReceived(amountToAddInput, customer.CustomerBalance);

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("ERROR: Invalid Input. Amount to add must be less than $100 and balance cannot exceed $1000");
            }
        }
        /// <summary>
        /// This method displays the current stock at the Candy Shop
        /// </summary>
        public void ShowInventory()
        {
            Console.WriteLine();
            Console.WriteLine("**************************");
            Console.WriteLine("******* Inventory ********");
            Console.WriteLine("**************************");
            Console.WriteLine();
            Console.WriteLine("ID   Name                Wrapper   Qty       Price");

            foreach (Inventory item in invStore.ActiveStock)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
}
