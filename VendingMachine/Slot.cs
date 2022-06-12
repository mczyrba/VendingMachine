using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine;

namespace VendingMachine
{
    public class Slot : Product
    {
        //PROPERTIES
        //Inherited Props -> ProductName, ProductType, ProductPrice, ProductLocation, ProductTypeSound
        
        public int numberOfItems { get; set; } = 5;



        
        //CONSTRUCTOR
        public Slot(string productLocation, string productName, double productPrice, string productType ) : base(productLocation, productName, productPrice, productType )
        {
            


        }


        //METHODS

        
    }
}
