using System;
using Microsoft.Data.Sqlite;


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
    }
}