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

                if (userChoice == 1)
                {

                    Console.Clear();
                    foreach (Slot item in stockInMachine)
                    {
                        Console.WriteLine($"{item.ProductLocation} - {item.ProductName} - {item.ProductPrice} - {item.numberOfItems} remaining");
                    }
                    Console.WriteLine();
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine();
                    objVendingMachine.DisplayTopMenu(false);
                }
            }


            Console.ReadLine();
        }//END OF MAIN()

    }
}
