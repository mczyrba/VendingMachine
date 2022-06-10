using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class TheMachine
    {

        //PROPERTIES
        private double SalesTotal { get; set; }
        private double CurrentMoneyProvided { get; set; }
        public double MoneyRemaing { get; set; }
        public string CurrentState { get; set; } = "Ready";
        public Dictionary<string, int> NumberOfItemsSold = new Dictionary<string, int>();
        public List<string> TransactionLog = new List<string>();


        //CONSTRUCTOR



        //METHODS
        public double MakeChange(double itemPrice)
        {
            double yourChange = 0;
            //CALCULATE CHANGE TO GIVE BACK
            if(CurrentMoneyProvided > MoneyRemaing)
            {
                MoneyRemaing -= itemPrice;
                yourChange = MoneyRemaing;
            }
            else
            {
                MoneyRemaing = CurrentMoneyProvided - itemPrice;
                yourChange = MoneyRemaing;
            }
            return yourChange;
        }

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
        }
        public int DisplayTopMenu(bool clearScreen)
        {
            int numSelected = 1;
            string menuSelection = "";


            //--- DISPLAY TOP MENU
            if (clearScreen)
            {
                Console.Clear();
            }
                
                Console.WriteLine("Please make a selection 1, 2 or 3");
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
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
                        }
                        Console.WriteLine("(1) Display Vending Machine Items");
                        Console.WriteLine("(2) Purchase");
                        Console.WriteLine("(3) Exit");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid number. Please try again.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Please make a selection 1, 2 or 3");
                        menuSelection = Console.ReadLine();
                    }

                    return numSelected;
                }
                
            
        }//END DISPLAYTOPMENU()
        public int DisplaySubMenu(double currMoneyProvided, bool clearScreen )
        {
            int numSelected = 1;
            string menuSelection = "";


            //--- DISPLAY SUB MENU( TL CHOICE 2)
            if (clearScreen)
            {
                Console.Clear();
            }
            Console.WriteLine($"Current Money Provided: ${currMoneyProvided}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");

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
                    }
                    Console.WriteLine($"Current Money Provided: ${currMoneyProvided}");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("(1) Feed Money");
                    Console.WriteLine("(2) Select Product");
                    Console.WriteLine("(3) Finish Transaction");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid number. Please try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Please make a selection 1, 2 or 3");
                    menuSelection = Console.ReadLine();
                }

                return numSelected;
            }



        }

    }
}
