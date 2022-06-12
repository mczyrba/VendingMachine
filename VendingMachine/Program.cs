using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Globalization;
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
           // Dictionary<string, Slot> inventoryDic = new Dictionary<string, Slot>();

            try
            {
                using (StreamReader inventory = new StreamReader(csvFilePath))
                {
                    while (!inventory.EndOfStream)
                    {
                        string line = inventory.ReadLine();
                        string[] arrOfCurrentLine = line.Split(',');
                        stockInMachine.Add
                            (new Slot(arrOfCurrentLine[0].ToString(), arrOfCurrentLine[1].ToString(), double.Parse(arrOfCurrentLine[2]), arrOfCurrentLine[3].ToString())
                            );
                       // inventoryDic[arrOfCurrentLine[0]] = new Slot(arrOfCurrentLine[0].ToString(), arrOfCurrentLine[1].ToString(), double.Parse(arrOfCurrentLine[2]), arrOfCurrentLine[3].ToString());

                     }
                }
                
            }
            catch(IOException ex)
            {
                Console.WriteLine("Oh no! Something went wrong! Unable to Continue");
                Console.WriteLine(ex.Message);
                objVendingMachine.CurrentState = "Not Ready";
                Console.WriteLine("Please press any key to EXIT The Machine");
            }

            
            if (objVendingMachine.CurrentState == "Ready")
            {
                //***********************************************]
                //*******   MAIN MENU   *************************]
                //***********************************************]
                int userChoice = objVendingMachine.DisplayTopMenu(true);

                if (userChoice == 1) // Main menu choice
                {
                    while (userChoice == 1) //Main Menu choice
                        {

                            DisplayItems();
                            userChoice = objVendingMachine.DisplayTopMenu(false);

                        }
                }
                if (userChoice == 2) //main menu choice
                {
                    userChoice = objVendingMachine.DisplaySubMenu(true);

                    while(userChoice == 1 ) //submenu choice
                        {
                        
                            objVendingMachine.FeedMe();
                            userChoice = objVendingMachine.DisplaySubMenu(true);
                        }

                    // copy the top menu choice  1-- this is to get us to a new breakout menu with the displaying the items and propting user for selection
                    //this is needing to be enapsulated in choice 2
                    if (userChoice == 2) //submenu choice
                        {

                            DisplayItems();
                            Console.WriteLine("Please Select Desired Item Loc.:  ");
                            string locationSelected = Console.ReadLine();
                            Console.WriteLine($"You selected {locationSelected}");

                        }
                    // to format even columns or set product name to a specific amount of spaces
                    // currently in the menu to purchase or feed money or finish- (sub menu)

                    //make another while-- in the menu for purchasing, after a purchase (balance displayed is updated) new menu, "would
                    //you like to make another puchase y/n

                }
            }
            

            Console.ReadLine();



            //***********************************************]
            //*******  DISPLAYS ITEMS ON SCREEN  ************]
            //***********************************************]
            void DisplayItems()
                {
                    Console.Clear();
                    objVendingMachine.DisplayBanner();
                    Console.WriteLine("=================================================");
                    Console.WriteLine("| Loc |       Item           | Price  | # Items |");
                    Console.WriteLine("=================================================");
                    foreach (Slot item in stockInMachine)
                    {
                        Console.WriteLine(string.Format("| {0,-3} | {1,-20} | {2,-7}|{3,5}    |",
                            item.ProductLocation,
                            item.ProductName,
                            item.ProductPrice.ToString("C", CultureInfo.CurrentCulture),
                            item.numberOfItems)); ;
                    }
                    Console.WriteLine("=================================================");
                    Console.WriteLine();
                    Console.WriteLine();
                }


        }//END OF MAIN()

    }
}
