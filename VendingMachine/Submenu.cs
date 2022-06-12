using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace VendingMachine
{
    class Submenu : TheMachine
    {
        public int SubMenuSelect { get; set; }


        //***********************************************]
        //*******   DISPLAY SUB MENU  *******************]
        //***********************************************]
        public void DisplaySubMenu(bool clearScreen)
        {
            int numSelected = 1;
            string menuSelection = "";


            //--- DISPLAY SUB MENU( MAIN MENU CHOICE 2)
            if (clearScreen)
            {
                Console.Clear();
                DisplayBanner();
            }
            Console.WriteLine($"Available Balance: {this.AvailableBalance.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine("(4) Cancel and return to Main Menu");

            menuSelection = Console.ReadLine();

            if (int.TryParse(menuSelection, out numSelected) && (int.Parse(menuSelection) >= 1 && int.Parse(menuSelection) <= 4))
            {
                //  return numSelected;
                if (numSelected == 2) //main menu choice
                {
                    DisplaySubMenu(true);

                    while (numSelected == 1) //submenu choice
                    {

                        this.FeedMe();
                       DisplaySubMenu(true);
                    }

                    // copy the top menu choice  1-- this is to get us to a new breakout menu with the displaying the items and propting user for selection
                    //this is needing to be enapsulated in choice 2
                    if (numSelected == 2) //submenu choice
                    {

                        DisplayItems();
                        Console.WriteLine("Please Select Desired Item Loc.:  ");
                        string locationSelected = Console.ReadLine();
                        while (DispenceProduct(locationSelected))
                        {
                            DisplayItems();
                            Console.WriteLine("Please Select Desired Item Loc.:  ");
                            locationSelected = Console.ReadLine();
                        }
                        DisplaySubMenu(true);

                    }
                    // to format even columns or set product name to a specific amount of spaces
                    // currently in the menu to purchase or feed money or finish- (sub menu)

                    //make another while-- in the menu for purchasing, after a purchase (balance displayed is updated) new menu, "would
                    //you like to make another puchase y/n

                }

            }
            else
            {
                //--- Make sure user selects valid choice

                while (!int.TryParse(menuSelection, out numSelected) || (int.Parse(menuSelection) < 0 || int.Parse(menuSelection) > 4))
                {
                    if (clearScreen)
                    {
                        Console.Clear();
                        DisplayBanner();
                    }
                    Console.WriteLine($"Current Money Provided: ${this.AvailableBalance}");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("(1) Feed Money");
                    Console.WriteLine("(2) Select Product");
                    Console.WriteLine("(3) Finish Transaction");
                    Console.WriteLine("(4) Cancel and return to Main Menu");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid number. Please try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Please make a selection 1, 2 or 3");
                    menuSelection = Console.ReadLine();
                }

                SubMenuSelect = numSelected;
            }
        }//end of display sub menu

    }
}
