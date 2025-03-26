using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace _291_proj
{
    public class TestDatabaseConnection
    {
        /// <summary>
        /// Simple utility to test database connection and verify the Movies table exists
        /// </summary>
        public static void RunTest()
        {
            Console.WriteLine("Testing database connection...");
            Console.WriteLine("Connection string: " + DataAccess.GetConnectionStringForDisplay());
            
            try
            {
                // Test basic connection
                using (SqlConnection conn = DataAccess.GetConnection())
                {
                    Console.WriteLine("Attempting to open connection...");
                    conn.Open();
                    Console.WriteLine("SUCCESS: Connection opened successfully!");
                    
                    // Test if MovieRentalDB exists
                    Console.WriteLine("\nChecking if MovieRentalDB exists...");
                    string dbQuery = "SELECT DB_ID('MovieRentalDB')";
                    using (SqlCommand cmd = new SqlCommand(dbQuery, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            Console.WriteLine("SUCCESS: MovieRentalDB exists!");
                        }
                        else
                        {
                            Console.WriteLine("ERROR: MovieRentalDB does not exist!");
                            Console.WriteLine("Please run the SQL script in SQL_scripts/CreateMovieDB.sql");
                            return;
                        }
                    }
                    
                    // Test if Movies table exists and has data
                    Console.WriteLine("\nChecking if Movies table exists and has data...");
                    string tableQuery = "SELECT COUNT(*) FROM MovieRentalDB.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Movies'";
                    using (SqlCommand cmd = new SqlCommand(tableQuery, conn))
                    {
                        int tableExists = (int)cmd.ExecuteScalar();
                        if (tableExists > 0)
                        {
                            Console.WriteLine("SUCCESS: Movies table exists!");
                            
                            // Check for data
                            string dataQuery = "SELECT COUNT(*) FROM MovieRentalDB.dbo.Movies";
                            cmd.CommandText = dataQuery;
                            int rowCount = (int)cmd.ExecuteScalar();
                            Console.WriteLine($"Found {rowCount} movies in the database.");
                            
                            if (rowCount > 0)
                            {
                                Console.WriteLine("\nListing movie names:");
                                string namesQuery = "SELECT TOP 5 Name FROM MovieRentalDB.dbo.Movies";
                                cmd.CommandText = namesQuery;
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        Console.WriteLine($"- {reader["Name"]}");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("WARNING: Movies table is empty. Run the sample data script.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ERROR: Movies table does not exist!");
                            Console.WriteLine("Please run the SQL script in SQL_scripts/CreateMovieDB.sql");
                        }
                    }
                }
                
                Console.WriteLine("\nAll tests completed.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("\nERROR: SQL Exception occurred:");
                Console.WriteLine($"Error code: {ex.Number}");
                Console.WriteLine($"Message: {ex.Message}");
                
                if (ex.Number == 4060)
                {
                    Console.WriteLine("\nTip: Error 4060 indicates that the database 'MovieRentalDB' doesn't exist.");
                    Console.WriteLine("Run the SQL_scripts/CreateMovieDB.sql script to create it.");
                }
                else if (ex.Number == 18456)
                {
                    Console.WriteLine("\nTip: Error 18456 indicates login failed. Check your username and password.");
                }
                else if (ex.Number == 53 || ex.Number == 10061)
                {
                    Console.WriteLine("\nTip: Cannot connect to the server. Possible reasons:");
                    Console.WriteLine("1. The server IP address or instance name is incorrect");
                    Console.WriteLine("2. SQL Server is not running or not accepting connections");
                    Console.WriteLine("3. A firewall is blocking the connection");
                    Console.WriteLine("4. If using Docker, check if port 1433 is properly exposed");
                    Console.WriteLine("\nTry the alternative connection strings in Alternative_Connection_Strings.txt");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nERROR: General Exception occurred:");
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
