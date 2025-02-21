using System;
using System.Data;
using System.Runtime.InteropServices;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.FileIO;


namespace HabitTrackerApp 
{
    class Program
    {
        static string connectionString = @"Data Source=HabitTrackerApp.db";

        static void Main(string[] args)
        {

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = 
                    @"CREATE TABLE IF NOT EXISTS drinking_water(
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Date TEXT,
                        Quantity INTEGER
                        );";

                tableCmd.ExecuteNonQuery();

                connection.Close();
            }

            GetUserInput();

        }

        static void GetUserInput()
        {
            Console.Clear();
            bool closeApp = false;
            
            while (closeApp == false)
            {
                Console.WriteLine("\n\nMAIN MENU");
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("Type 1 to view all records");
                Console.WriteLine("Type 2 to add a new record");
                Console.WriteLine("Type 3 to delete a record");
                Console.WriteLine("Type 4 to update a record");
                Console.WriteLine("------------------------------------------------\n");

                string commandInput = Console.ReadLine();

                switch(commandInput)
                {
                    case "1":
                    // View all records
                        GetAll();
                        closeApp = true;
                        break;
                    case "2":
                        Create();
                        closeApp = true;
                        break;
                    case "3":
                        Delete();
                        closeApp = true;
                        break;
                    case "4":
                        Update();
                        closeApp = true;
                        break; 
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;               
                }
            }
        }

        static void GetAll()
        {

        }

        static void Create()
        {
            string date = GetDateInput();

            int quantity = GetNumberInput("\n\nPlease insert a number of glasses or other measure of your choice (no decimals allowed).\n\n");
            
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = 
                        $"INSERT INTO drinking_water(date, quantity) VALUES ('{date}', {quantity})";

                tableCmd.ExecuteNonQuery();

                connection.Close();
            }

        
        }

        static void Delete()
        {

        }

        static void Update()
        {

        }

        internal static string GetDateInput()
        {
            Console.WriteLine("Please enter the date (dd/mm/yyyy). Type 0 to return to main menu: ");
            string dateInput = Console.ReadLine();
            
            if (dateInput == "0") GetUserInput();
            return dateInput;
        }

        internal static int GetNumberInput(string message)
        {
            Console.WriteLine(message);
            string numberInput = Console.ReadLine();

            if(numberInput == "0") GetUserInput();

            int finalInput = Convert.ToInt32(numberInput);
            return finalInput;
            
        }
    }

    
}