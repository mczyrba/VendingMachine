using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace VendingMachine
{
    class TheMachine
    {

        //PROPERTIES
        private double SalesTotal { get; set; }
        private double CurrentMoneyProvided { get; set; }
        public double AvailableBalance { get; set; }
        //public double MoneyRemaining {get{currentMoneyProvide - itemprice};} 
        public string CurrentState { get; set; } = "Ready";
        
        public Dictionary<string, int> NumberOfItemsSold = new Dictionary<string, int>();
        public List<string> TransactionLog = new List<string>();


        //CONSTRUCTOR



        //METHODS



        //***********************************************]
        //*******   MAKE CHANGE  ************************]
        //***********************************************]
        public double MakeChange(double itemPrice)
        {
            double yourChange = 0;
            //CALCULATE CHANGE TO GIVE BACK

                AvailableBalance -= itemPrice;
                yourChange = AvailableBalance;
          
            return yourChange;
        }



        //***********************************************]
        //*******   WRITE TO LOG FILE  ******************]
        //***********************************************]
        public bool WriteToLogFile()
        {
            
            string directory = Environment.CurrentDirectory;
            string logFileName = "SalesLog.txt";
            string logFilePath = directory + logFileName;
            

                try
                {
                    using (StreamWriter logWriter = new StreamWriter(logFilePath, true))
                    {
                        foreach (string line in TransactionLog)
                        {
                            logWriter.WriteLine(line);
                        }
                    }

                    
                }
                catch (IOException ex)
                {
                    return false;
                }

            return true;
        }//End of MakeChange()

        //***********************************************]
        //*******   DISPLAY MAIN MENU  ******************]
        //***********************************************]
        public int DisplayTopMenu(bool clearScreen)
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
                    return numSelected;
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

                    return numSelected;
                }
                
            
        }//END DISPLAYTOPMENU()

        //***********************************************]
        //*******   DISPLAY SUB MENU  *******************]
        //***********************************************]
        public int DisplaySubMenu(bool clearScreen)
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
                return numSelected;
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

                return numSelected;
            }
        }//end of display sub menu



        //***********************************************]
        //*******   FEED MONEY IN  **********************]
        //***********************************************]
        public void FeedMe()
            {
            Console.Clear();
            DisplayBanner();
            Console.WriteLine($"Available Balance: {this.AvailableBalance.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine("(4) Cancel and return to Main Menu");
                double moneyEntered = 0;
            Console.WriteLine();
            Console.WriteLine();
                Console.WriteLine("Enter amount to add:");
                string amountAdded = Console.ReadLine();

                //--- Make sure user enters an double

                while (!double.TryParse(amountAdded, out moneyEntered) || (double.Parse(amountAdded) < 0))
                    {
                        Console.WriteLine("Amount to add:");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please add appropriate funds.");
                        Console.ForegroundColor = ConsoleColor.White;
                        amountAdded = Console.ReadLine();

                    }


                //--- add money fed in to AvailableBalance
                this.AvailableBalance += double.Parse(amountAdded);
                
                
        }//END OF FEED ME


        //***********************************************]
        //*******   DISPLAY TITLE BANNER  ***************]
        //***********************************************]

        public void DisplayBanner()
        {
            //--- DISPLAY BANNER

            Console.WriteLine(@" ________ __            _    _            _ ");
            Console.WriteLine(@"|___   __|| |          |  \/  |          | |   (_)");
            Console.WriteLine(@"    | |   | |__   ___  | \  / | __ _  ___| |__  _ _ __   ___");
            Console.WriteLine(@"    | |   | '_ \ / _ \ | |\/| |/ _` |/ __| '_ \| | '_ \ / _ \");
            Console.WriteLine(@"    | |   | | | |  __/ | |  | | (_| | (__| | | | | | | | __ / ");
            Console.WriteLine(@"    |_|   |_| |_|\___| |_|  |_|\__,_|\___|_| |_|_|_| |_|\___| ");
            Console.WriteLine("\n\n");
        }

    }
}
