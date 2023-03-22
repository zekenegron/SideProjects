using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Sour : Inventory
    {
        public Sour (string type, string id, string name, decimal price, bool wrap) : base(type, id, name, price, wrap)
        {
            Descrip = "Sour Flavored Candies";

        }
    }
}
