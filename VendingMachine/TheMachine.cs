using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Globalization;
using VendingMachine;

using System.Threading.Tasks;

namespace VendingMachine
{
    public class TheMachine
    {

        //PROPERTIES
        private double SalesTotal { get; set; }
        private double CurrentMoneyProvided { get; set; }
        public double AvailableBalance { get; set; }
        //public double MoneyRemaining {get{currentMoneyProvide - itemprice};} 
        public string CurrentState { get; set; } //= "Ready";
        
        public Dictionary<string, int> NumberOfItemsSold { get; } = new Dictionary<string, int>();
        public List<string> TransactionLog { get; } = new List<string>();
        public List<Slot> StockedItemsInMachine { get; } = new List<Slot>();

        //CONSTRUCTOR
        public TheMachine(List<Slot> listOfItems4Sale)
        {
            CurrentState = "Ready";
            StockedItemsInMachine = listOfItems4Sale;
        }


        //METHODS

        //***********************************************]
        //*******   DISPENCE ITEM  **********************]
        //***********************************************]
        public bool DispenceProduct(string userSelection)
        {
            //Dispensing an item prints the item name, cost, and the money remaining. Dispensing also returns a sound message:
            bool selectAgain = true;
            bool itemfound = false;

            foreach (Slot item in StockedItemsInMachine)
            {
                if (userSelection.ToUpper() == item.ProductLocation)
                {
                    itemfound = true;

                    if (item.numberOfItems > 0)
                    {
                        if (item.ProductPrice <= AvailableBalance)
                        {
                            item.numberOfItems--;
                            this.AvailableBalance -= item.ProductPrice;

                            Console.WriteLine($"Here is your {item.ProductName}({item.ProductPrice.ToString("C", CultureInfo.CurrentCulture)}) - remaining funds: {this.AvailableBalance.ToString("C", CultureInfo.CurrentCulture)}");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(item.ProductTypeSound);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");
                            TransactionLog.Add($"{DateTime.Now.ToString(CultureInfo.CurrentCulture)} PURCHASED {item.ProductType} loc[{item.ProductLocation}] {item.ProductPrice.ToString("C", CultureInfo.CurrentCulture)} Available Funds: {AvailableBalance.ToString("C", CultureInfo.CurrentCulture) }" );
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Transaction cancelled due to insufficient funds");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write($"Available Balance: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{AvailableBalance.ToString("C", CultureInfo.CurrentCulture) }");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Oops! Item is Sold Out.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"Available Balance: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{AvailableBalance.ToString("C", CultureInfo.CurrentCulture) }");
                        Console.ForegroundColor = ConsoleColor.White;
                    }


                }

            }
            if (!itemfound)
            {
                Console.WriteLine("Please choose a valid selection.");

            }

            Console.WriteLine("Do you want to make another selection?(Y/N)");
            string doYouWantAnother = Console.ReadLine();

            if (doYouWantAnother == "N" || doYouWantAnother == "n")
            {
                selectAgain = false;
            }
            return selectAgain;

        }




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
        public string WriteToLogFile()
        {
            
            string directory = Environment.CurrentDirectory;
            string logFileName = "SalesLog.txt";
            string logFilePath = directory + logFileName;
            

                try
                {
                    using (StreamWriter logWriter = new StreamWriter(logFilePath, true)) //--Appends to log file
                    {
                        foreach (string line in TransactionLog)
                        {
                            logWriter.WriteLine(line);
                        }
                    }


                
                }
                catch (IOException ex)
                {
                Console.WriteLine("Could Not Write To Log File");
                Console.WriteLine(ex.Message);
                    return "An Error ocurredwhen completing your transaction. Please call your bank.";
                }

            return $"Your Transaction is complete. YourChange = {AvailableBalance.ToString("C", CultureInfo.CurrentCulture)}\nThank you.";
        }//End of MakeChange()

       

        


        //***********************************************]
        //*******   FEED MONEY IN  **********************]
        //***********************************************]
        public void FeedMe()
            {
            //Console.Clear();
            //DisplayBanner();
            //Console.WriteLine($"Available Balance: {this.AvailableBalance.ToString("C", CultureInfo.CurrentCulture)}");
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("(1) Feed Money");
            //Console.WriteLine("(2) Select Product");
            //Console.WriteLine("(3) Complete Transaction");
            //Console.WriteLine("(4) Cancel and return to Main Menu");
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

            Console.WriteLine(@" ________  _            _    _            _ ");
            Console.WriteLine(@"|___   __|| |          |  \/  |          | |   (_)");
            Console.WriteLine(@"    | |   | |__   ___  | \  / | __ _  ___| |__  _ _ __   ___");
            Console.WriteLine(@"    | |   | '_ \ / _ \ | |\/| |/ _` |/ __| '_ \| | '_ \ / _ \");
            Console.WriteLine(@"    | |   | | | |  __/ | |  | | (_| | (__| | | | | | | | __ / ");
            Console.WriteLine(@"    |_|   |_| |_|\___| |_|  |_|\__,_|\___|_| |_|_|_| |_|\___| ");
            Console.WriteLine();
        }

        //***********************************************]
        //*******  DISPLAYS ITEMS ON SCREEN  ************]
        //***********************************************]
        public void DisplayItems()
        {
            Console.Clear();
            this.DisplayBanner();
            Console.WriteLine("=================================================");
            Console.WriteLine("| Loc |       Item           | Price  | # Items |");
            Console.WriteLine("=================================================");
            foreach (Slot item in this.StockedItemsInMachine)
            {
                if(item.numberOfItems <= 0)
                {
                    Console.Write(string.Format("| {0,-3} | {1,-20} | {2,-7}",
                    item.ProductLocation,
                    item.ProductName,
                    item.ProductPrice.ToString("C", CultureInfo.CurrentCulture)));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("|Sold Out |");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine(string.Format("| {0,-3} | {1,-20} | {2,-7}|{3,5}    |",
                    item.ProductLocation,
                    item.ProductName,
                    item.ProductPrice.ToString("C", CultureInfo.CurrentCulture),
                    item.numberOfItems));
                }
                
            }
            Console.WriteLine("=================================================");
            
        }

    }
}
