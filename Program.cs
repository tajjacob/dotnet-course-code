// 36. Database Connections

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
                ReleaseDate = new DateTime(2021, 6, 15),
                Price = 1299.99m,
                VideoCard = "NVIDIA GeForce RTX 3080"
            };
            myComputer.Price = 1199.99m; // you can change properties if they have a set accessor
            Console.WriteLine($"My computer has the following specs:");
            Console.WriteLine($"Motherboard: {myComputer.Motherboard}");
            Console.WriteLine($"CPU Cores: {myComputer.CPUCore}");
            Console.WriteLine($"Has Wifi: {myComputer.HasWifi}");
            Console.WriteLine($"Has LTE: {myComputer.HasLTE}");
            Console.WriteLine($"Release Date: {myComputer.ReleaseDate.ToShortDateString()}");
            Console.WriteLine($"Price: ${myComputer.Price}");
            Console.WriteLine($"Video Card: {myComputer.VideoCard}");
        }
    }
}
