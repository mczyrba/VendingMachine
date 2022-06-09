using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Chips
    {
        public string ProductSound { get; }
        public Chips(string productType, string productName, string productSound, double productPrice, string sound)
        {
            ProductSound = sound;
        }
    }
}
