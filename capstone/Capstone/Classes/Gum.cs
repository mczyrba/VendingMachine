using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    class Gum
    {
        public string ProductSound { get; }
        public Gum(string productType, string productName, string productSound, double productPrice, string sound)
        {
            ProductSound = sound;
        }
    }
}
