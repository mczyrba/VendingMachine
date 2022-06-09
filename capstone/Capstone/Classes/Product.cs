using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Product
    {
        public string ProductType { get; }
        public string ProductName { get; }

        public double ProductPrice { get; }



        public Product(string productType, string productName, string productSound, double productPrice)
        {
            ProductType = productType;
            ProductName = productName;
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
