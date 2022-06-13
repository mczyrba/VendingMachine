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
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please Standby.......");

                      

            //***********************************************]
            //*******   Create inventory    *****************]
            //***********************************************]
            string directory = Environment.CurrentDirectory;
            string csvFileName = "vendingmachine.csv";
            string csvFilePath = directory + csvFileName;
           
           // Dictionary<string, Slot> inventoryDic = new Dictionary<string, Slot>();
            List<Slot> inventoryList = new List<Slot>();


            try
            {
                using (StreamReader inventory = new StreamReader(csvFilePath))
                {
                    while (!inventory.EndOfStream)
                    {
                        string line = inventory.ReadLine();
                        string[] arrOfCurrentLine = line.Split(',');
                        inventoryList.Add
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
                //objVendingMachine.CurrentState = "Not Ready";
                Console.WriteLine("Please press any key to EXIT The Machine");
            }

            //--- SPIN UP TheMachine
            TheMachine objVendingMachine = new TheMachine(inventoryList);

            if (objVendingMachine.CurrentState == "Ready")
            {
                //***********************************************]
                //*******   MAIN MENU   *************************]
                //***********************************************]

                Menu TopMenu = new Menu(objVendingMachine.StockedItemsInMachine);
                TopMenu.DisplayTopMenu(true);

             
               
            }
            

            Console.ReadLine();



           
            


        }//END OF MAIN()

    }
}
