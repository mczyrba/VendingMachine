using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please Standby.......");

            //--- SPIN UP TheMachine
            TheMachine objVendingMachine = new TheMachine();

            //***********************************************]
            //*******   Create inventory    *****************]
            //***********************************************]
            string directory = Environment.CurrentDirectory;
            string csvFileName = "vendingmachine.csv";
            string csvFilePath = directory + csvFileName;
            List<Slot> stockInMachine = new List<Slot>(); 

            try
            {
                using (StreamReader inventory = new StreamReader(csvFilePath))
                {
                    while (!inventory.EndOfStream)
                    {
                        string line = inventory.ReadLine();
                        string[] arrOfCurrentLine = line.Split(',');
                        stockInMachine.Add(new Slot(arrOfCurrentLine[0].ToString(), arrOfCurrentLine[1].ToString(), double.Parse(arrOfCurrentLine[2]), arrOfCurrentLine[3].ToString())
                        );

                     }
                }
                
            }
            catch(IOException ex)
            {
                Console.WriteLine("Oh no! Something went wrong! Unable to Continue");
                Console.WriteLine(ex.Message);
                objVendingMachine.CurrentState = "Not Ready";
            }

            
            if (objVendingMachine.CurrentState == "Ready")
            {
                //***********************************************]
                //*******   TOP LEVEL MENU    *******************]
                //***********************************************]
                int userChoice = objVendingMachine.DisplayTopMenu(true);

                if (userChoice == 1) // top menu choice
                {

                    Console.Clear();
                    foreach (Slot item in stockInMachine)
                    {
                        Console.WriteLine($"{item.ProductLocation} - {item.ProductName} - {item.ProductPrice} - {item.numberOfItems} remaining");
                    }
                    Console.WriteLine();
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine();
                    userChoice = objVendingMachine.DisplayTopMenu(false);
                }
                if (userChoice == 2) //top menu choice
                {
                    userChoice = objVendingMachine.DisplaySubMenu(objVendingMachine.MoneyRemaing, true);
                    while(userChoice == 1 ) //submenu choice
                    {
                        double balance = objVendingMachine.FeedMe();
                        userChoice = objVendingMachine.DisplaySubMenu(balance, true);
                    }

                    // copy the top menu choice  1-- this is to get us to a new breakout menu with the displaying the items and propting user for selection
                    //Console.Clear();
                    //foreach (Slot item in stockInMachine)
                    //{
                    //    Console.WriteLine($"{item.ProductLocation} - {item.ProductName} - {item.ProductPrice} - {item.numberOfItems} remaining");
                    //}
                    //Console.WriteLine();
                    //Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    //Console.WriteLine();

                    // currently in the menu to purchase or feed money or finish- (sub menu)

                    //make another while-- in the menu for purchasing, after a purchase (balance displayed is updated) new menu, "would
                    //you like to make another puchase y/n

                }
            }
            

            Console.ReadLine();
        }//END OF MAIN()

    }
}
