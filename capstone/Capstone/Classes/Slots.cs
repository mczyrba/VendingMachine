using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Slots : Product
    {
        public string Location { get;  }
        public int NumberOfItems { get; set; } = 5;


        public Slots(string productType, string productName, double productPrice) : base(productType, productName, productPrice) { }






    }
}
