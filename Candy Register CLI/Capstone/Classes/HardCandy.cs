﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class HardCandy : Inventory
    {
        public HardCandy(string type, string id, string name, decimal price, bool wrap) : base(type, id, name, price, wrap)
        {
            Descrip = "Hard Tack Confectionery";

        }

    }
}
