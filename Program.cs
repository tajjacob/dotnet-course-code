// 30. model

using System;
using System.Text.RegularExpressions;

namespace HelloWorld
{
      public class Computer
    {
        public string Motherboard { get; set; } = ""; //auto-implemented properties. for non-nullable reference types, you must initialize them
        public int CPUCores { get; set; } // get - Retrieves (reads) the value, set - Assigns (writes) the value
        public bool HasWifi { get; set; }
        public bool HasLTE { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string VideoCard { get; set; } = "";
    } 

    internal class Program
    {
        static void Main(string[] args)
        {
            Computer myComputer = new Computer()
            {
                Motherboard = "ASUS ROG STRIX B550-F GAMING",
                CPUCores = 8,
                HasWifi = true,
                HasLTE = true,
                ReleaseDate = new DateTime(2021, 6, 15),
                Price = 1299.99m,
                VideoCard = "NVIDIA GeForce RTX 3080"
            };
            myComputer.Price = 1199.99m; // you can change properties if they have a set accessor
            Console.WriteLine($"My computer has the following specs:");
            Console.WriteLine($"Motherboard: {myComputer.Motherboard}");
            Console.WriteLine($"CPU Cores: {myComputer.CPUCores}");
            Console.WriteLine($"Has Wifi: {myComputer.HasWifi}");
            Console.WriteLine($"Has LTE: {myComputer.HasLTE}");
            Console.WriteLine($"Release Date: {myComputer.ReleaseDate.ToShortDateString()}");
            Console.WriteLine($"Price: ${myComputer.Price}");
            Console.WriteLine($"Video Card: {myComputer.VideoCard}");
        }
    }
}
