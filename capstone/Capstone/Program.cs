using System;
using System.IO;

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the last vending machine you will ever need.");
            Console.WriteLine("Please choose from the following options by selecting the corresponding number.");
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
            string input = Console.ReadLine();

            if (input.Length != 1)
            {

                Console.WriteLine("Inputs can only be single numbers and 1-3. Please try again");

            }
            else if (int.Parse(input) > 4 && int.Parse(input) < 1)
            {
                Console.WriteLine("Inputs can only be single numbers and 1-3. Please try again");
            }
        }

        static void ReadFileToArray()
        {
            string path = @"C:\Users\Student\git\c - sharp - mini - capstone - module - 1 - team - 2\capstone;";
            string file = "vendingmachine.csv";

            string fullPath = Path.Combine(path, file);

            string[] productInfo = new string[4];

            using (StreamReader sr = new StreamReader(fullPath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    productInfo = line.Split(',');
                }
            }
        }


    }
}
