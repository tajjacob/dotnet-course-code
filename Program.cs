// 40. Dapper Pt 2

using System;
using System.Data;
using System.Text.RegularExpressions;
using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;

namespace HelloWorld
{
  

    internal class Program
    {
        static void Main(string[] args)
        {
            DataContextDapper dapper = new DataContextDapper();
            DateTime rightNow = dapper.LoadDataSingle<DateTime>("SELECT GETDATE()"); // explanation: This line executes the SQL command and retrieves the first result as a DateTime object.

            // Console.WriteLine(rightNow.ToShortDateString());
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
            
            bool result = dapper.ExecuteSql(sql);
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

            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

            foreach(Computer computer in computers)
            {
                Console.WriteLine($" Motherboard: {computer.Motherboard}, Price: {computer.Price}");
            }

        }
    }
}
