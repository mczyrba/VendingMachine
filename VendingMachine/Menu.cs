using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Menu : TheMachine
    {
        //PROPERTIES
        public int MenuSelection { get; set; }
        private string MenuLevel { get; set; } = "Top";
        private string MessageToUser { get; set; }


        //CONSTRUCTOR
        public Menu(List<Slot> itemList) : base(itemList)
        {

        }


        //METHODS

        //***********************************************]
        //*******   DISPLAY MAIN MENU  ******************]
        //***********************************************]
        public void DisplayTopMenu(bool clearScreen)
        {
            int numSelected = 0;
            string menuSelection = "";
            MenuLevel = "Top";

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
            if(!String.IsNullOrEmpty(MessageToUser))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(MessageToUser);
                Console.ForegroundColor = ConsoleColor.White;
            }
            MessageToUser = "";

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
                    if (!String.IsNullOrEmpty(MessageToUser))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(MessageToUser);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    MessageToUser = "";
                    menuSelection = Console.ReadLine();
                }

                MenuSelection = numSelected;
                this.ActOnSelection();
            }


        }//END DISPLAYTOPMENU()


        //***********************************************]
        //*******   ACTION TO TAKE    *******************]
        //***********************************************]
        public void ActOnSelection()
        {
            if(MenuLevel == "Top")
            {
                if (MenuSelection == 1) // Main menu choice
                {
                    while (MenuSelection == 1) //Main Menu choice
                    {

                        DisplayItems();
                        DisplayTopMenu(false);

                    }
                }
                else if (MenuSelection == 2)
                {
                    //GoTo Submenu
                    MenuLevel = "Sub";
                    MenuSelection = 0;
                    DisplaySubMenu(true);
                }
                else if (MenuSelection == 3)
                {
                    //Exit App
                    //GOOD BYE!!
                    Environment.Exit(0);
                }
                else
                {
                    this.DisplayTopMenu(true);
                }
            }
            else if(MenuLevel == "Sub")
            {
                //Act on SubMenu choice
                while (MenuSelection == 1) //submenu choice
                {

                    this.FeedMe();
                    DisplaySubMenu(true);
                }


                if (MenuSelection == 2) //submenu choice
                {

                    DisplayItems();
                    Console.WriteLine("Please Select Desired Item Loc. (Ex: A1):  ");
                    string locationSelected = Console.ReadLine();
                    while (DispenceProduct(locationSelected))
                    {
                        DisplayItems();
                        Console.WriteLine("Please Select Desired Item Loc.:  ");
                        locationSelected = Console.ReadLine();
                    }
                    DisplaySubMenu(true);

                }

                if(MenuSelection == 3)
                {
                    //complete trans
                    TransactionLog.Add($"{DateTime.Now.ToString(CultureInfo.CurrentCulture)} GIVE CHANGE {AvailableBalance.ToString("C", CultureInfo.CurrentCulture)} {0}");
                    MessageToUser =  WriteToLogFile();
                    AvailableBalance = 0;
                    MenuLevel = "Top";
                    MenuSelection = 0;
                    DisplayTopMenu(true);
                } 
                
                if(MenuSelection == 4)
                {
                    //Cancel transaction and GoTo MainMenu
                    TransactionLog.Clear();
                    MessageToUser = "Transaction Cancelled";
                    DisplayTopMenu(true);
                }


            }

        }


        //***********************************************]
        //*******   DISPLAY SUB MENU  *******************]
        //***********************************************]
        public void DisplaySubMenu(bool clearScreen)
        {
            int numSelected = 0;
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
            Console.WriteLine("(3) Complete Transaction");

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
                    Console.WriteLine($"Current Money Provided: {this.AvailableBalance.ToString("C", CultureInfo.CurrentCulture)}");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("(1) Feed Money");
                    Console.WriteLine("(2) Select Product");
                    Console.WriteLine("(3) Complete Transaction");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid number. Please try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Please make a selection 1, 2 or 3");
                    menuSelection = Console.ReadLine();
                }

                MenuSelection = numSelected;
                this.ActOnSelection();
            }
        }//end of display sub menu
    }
}
