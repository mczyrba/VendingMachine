using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void DispenceProduct(double moneyRemaining)
        {
            //Dispensing an item prints the item name, cost, and the money remaining. Dispensing also returns a sound message:
            this.numberOfItems--;
            Console.WriteLine($"Here is your {ProductName} - {ProductPrice}, remaining funds ${moneyRemaining}");
            Console.WriteLine(ProductTypeSound);

        }
    }
}
