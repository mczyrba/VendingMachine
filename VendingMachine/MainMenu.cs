using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class MainMenu : TheMachine
    {
        public int MenuSelection { get; set; }


        //***********************************************]
        //*******   DISPLAY MAIN MENU  ******************]
        //***********************************************]
        public void DisplayTopMenu(bool clearScreen)
        {
            int numSelected = 1;
            string menuSelection = "";

            //--- DISPLAY TOP MENU
            if (clearScreen)
            {
                Console.Clear();
                DisplayBanner();
            }

            Console.WriteLine("Please make a selection 1, 2 or 3");
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Make a Purchase \\ Add to Available Balance");
            Console.WriteLine("(3) Exit");
            menuSelection = Console.ReadLine();

            if (int.TryParse(menuSelection, out numSelected) && (int.Parse(menuSelection) >= 1 && int.Parse(menuSelection) <= 4))
            {
                MenuSelection = numSelected;
                this.ActOnSelection();
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
                    Console.WriteLine("(1) Display Vending Machine Items");
                    Console.WriteLine("(2) Purchase");
                    Console.WriteLine("(3) Exit");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid number. Please try again. \n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Please make a selection 1, 2 or 3");
                    menuSelection = Console.ReadLine();
                }

                MenuSelection = numSelected;
            }


        }//END DISPLAYTOPMENU()


        //Methods
        public void ActOnSelection()
        {
            if (MenuSelection == 1) // Main menu choice
            {
                while (MenuSelection == 1) //Main Menu choice
                {

                    DisplayItems();
                    DisplayTopMenu(false);

                }
            }


        }
    }
}
