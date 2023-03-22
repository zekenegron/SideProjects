using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Capstone.Classes
{
    public class Inventory
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public bool IsIndiWrap { get; set; }
        public int Quantity { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        private const int MaxQuantity = 100;
        public string Descrip { get; set; } = "";

        public Inventory(string type, string id, string name, decimal price,  bool wrap)
        {
            this.Type = type;
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.IsIndiWrap = wrap;
            this.Quantity = MaxQuantity;
        }

        /// <summary>
        /// Overriding ToString() in this class to display standard format in "Show Inventory" section
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string wrapped = "";
            if(IsIndiWrap == true)
            {
                wrapped = "Y";
            }
            else
            {
                wrapped = "N"; 
            }
            if(Quantity == 0)
            {
                string soldOut = "SOLD OUT!";
                return $"{Id.PadRight(5)}{Name.PadRight(20)}{wrapped.PadRight(10)}{soldOut.PadRight(10)}{Price}";
            }
            else
            {
                return $"{Id.PadRight(5)}{Name.PadRight(20)}{wrapped.PadRight(10)}{Quantity.ToString().PadRight(10)}{Price}";
            }           
        }
    }
}
