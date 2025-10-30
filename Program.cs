// 40. Dapper Pt 1

using System;
using System.Data;
using System.Text.RegularExpressions;
using Dapper;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;

namespace HelloWorld
{
  

    internal class Program
    {
        static void Main(string[] args)
        {
            // string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=True;Trusted_Connection=true;";// for windows authentication
            string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=True;Trusted_Connection=false;User Id=sa;Password=SQLConnect1!;"; // for mac or linux authentication

            IDbConnection dbConnection = new SqlConnection(connectionString); // explanation: This creates a new SQL connection using the provided connection string.

            string sqlCommand = "SELECT GETDATE()"; // explanation: This SQL command is intended to select the current date from the database

            // dbConnection.Query<DateTime>(sqlCommand); // explanation: This line executes the SQL command against the database and maps the result to a collection of DateTime objects.

            DateTime rightNow = dbConnection.QueryFirst<DateTime>(sqlCommand); // explanation: This line executes the SQL command and retrieves the first result as a DateTime object.

            Console.WriteLine(rightNow.ToShortDateString());
            Computer myComputer = new Computer()

            {
                Motherboard = "ASUS ROG STRIX B550-F GAMING",
                CPUCore = 8,
                HasWifi = true,
                HasLTE = true,
                ReleaseDate = DateTime.Now,
                Price = 1299.99m,
                VideoCard = "NVIDIA GeForce RTX 5010"
            };

            string sql = @"INSERT INTO TutorialAppSchema.Computer 
                           (Motherboard, CPUCore, HasWifi, HasLTE, ReleaseDate, Price, VideoCard) 
                           VALUES 
                           (@Motherboard, @CPUCore, @HasWifi, @HasLTE, @ReleaseDate, @Price, @VideoCard);"; // Using named parameters for better readability and maintainability
                

            Console.WriteLine(sql);


            // Dapper automatically maps properties of myComputer to the named parameters in the SQL string.
            // It also handles proper type conversion and prevents SQL injection.
            int result = dbConnection.Execute(sql, myComputer);  // explanation: This line executes the SQL insert command using the properties of the myComputer object to fill in the parameter values.
            Console.WriteLine($"Number of rows inserted: {result}");

            string sqlSelect = @"
            SELECT 
                Computer.ComputerId,
                Computer.Motherboard,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
             FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = dbConnection.Query<Computer>(sqlSelect);

            foreach(Computer computer in computers)
            {
                Console.WriteLine($" Motherboard: {computer.Motherboard}, Price: {computer.Price}");
            }

        }
    }
}
