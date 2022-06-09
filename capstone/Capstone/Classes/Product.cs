using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Product
    {
        private string ProductType { get; }
        private string ProductName { get; }
        private string ProductSound { get; }
        private double ProductPrice { get; }



        public Product(string productType, string productName, string productSound, double productPrice)
        {
            ProductType = productType;
            ProductName = productName;
            ProductSound = productName;
            ProductPrice = productPrice;
        }

        public Product(string productType, string productName, double productPrice)
        {
            ProductType = productType;
            ProductName = productName;
            ProductPrice = productPrice;
        }
    }

    
}
