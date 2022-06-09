using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    class Beverages
    {
        public string ProductSound { get; }
        public Beverages(string productType, string productName, string productSound, double productPrice, string sound)
        {
            ProductSound = sound;
        }
    }
}
