using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Product
    {

        //PROPERTIES
        public string ProductName { get; }
        public string ProductType { get; }
        public double ProductPrice { get; }

        public string ProductTypeSound { get
            {
                if(this.ProductType == "Chip") { return "Crunch Crunch, Yum!"; }
                else if(this.ProductType == "Candy") { return "Munch Munch, Yum!"; }
                else if(this.ProductType == "Drink") { return "Slurp Slurp, Yum!"; }
                else if(this.ProductType == "Gum") { return "Chewy Chewy, Yum!"; }
                else { return "Nom Nom Nom!"; }
            }
        }
        public string ProductLocation { get; set; }

        
        
        //CONSTRUCTOR
        public Product(string productLocation, string productName, double productPrice, string productType)
        {
            ProductName = productName;
            ProductType = productType;
            ProductPrice = productPrice;
            ProductLocation = productLocation;
        }


        //METHODS


    }
}
