using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    class Candy
    {
        public string ProductSound { get; }
        public Candy(string productType, string productName, string productSound, double productPrice, string sound)
        {
            ProductSound = sound;
        }
    }
}
