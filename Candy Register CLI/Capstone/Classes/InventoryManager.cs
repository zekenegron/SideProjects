using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Capstone.Classes
{
    public class InventoryManager
    {
        public List<Inventory> ActiveStock { get; private set; }

        public InventoryManager()
        {
            ActiveStock = Load();
        }

        /// <summary>
        /// Loads in Inventory from CSV file
        /// </summary>
        /// <returns></returns>
        public List<Inventory> Load()
        {
            string csvFilePath = @"C:\Store\inventory.csv";

            List<Inventory> output = new List<Inventory>();

            using (StreamReader reader = new StreamReader(csvFilePath))
            {
                while(!reader.EndOfStream)
                {
                    string candyData = reader.ReadLine();

                    string[] candyParts = candyData.Split("|");

                    string type = candyParts[0].ToUpper();
                    string id = candyParts[1].ToUpper();
                    string name = candyParts[2];
                    decimal price = decimal.Parse(candyParts[3]);
                    bool wrap = false;
                    if (candyParts[4].ToUpper() == "T")
                    {
                        wrap = true;
                    }

                    switch(type)
                    {
                        case "CH":
                            Chocolate choco = new Chocolate(type, id, name, price, wrap);
                            output.Add(choco);
                            break;
                        case "SR":
                            Sour bad = new Sour(type, id, name, price, wrap);
                            output.Add(bad);
                            break;
                        case "HC":
                            HardCandy hardCandy = new HardCandy(type, id, name, price, wrap);
                            output.Add(hardCandy);
                            break;
                        case "LI":
                            Licorice lico = new Licorice(type, id, name, price, wrap);
                            output.Add(lico);
                            break;
                    }
                }
            }

            return output;
        }
        
        /// <summary>
        /// This verifies whether the ID a customer entered while trying to make a purchase actually exists
        /// </summary>
        /// <param name="inputId">ID of desired item to purchase</param>
        /// <returns></returns>
        public Inventory FindID (string inputId)
        {
            foreach (Inventory item in ActiveStock)
            {
                if(item.Id == inputId.ToUpper())
                {
                    return item;
                }
            }
         
            return null;
        }

        public bool IsInStock(Inventory itemToCheck, int numOfItems)
        {
            if (numOfItems <= itemToCheck.Quantity)
            {
                    return true;
            }
            return false;
        }
    }
}
