using System;
using System.Data;
using System.Runtime.InteropServices;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.FileIO;


namespace HabitTrackerApp 
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=HabitTrackerApp.db";

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
        }

        static void GetUserInput()
        {
            Console.Clear();
            bool closeApp = false;
            
            while (closeApp = false)
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
                    case 1:
                    // View all records
                        GetAll();
                        closeApp = true;
                        break;
                    case 2:
                        Create();
                        closeApp = true;
                        break;
                    case 3:
                        Delete();
                        closeApp = true;
                        break;
                    case 4:
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
            
        }

        static void Delete()
        {

        }

        static void Update()
        {

        }
    }

    
}