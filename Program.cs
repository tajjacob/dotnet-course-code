// 19. Data Structures 

using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] myGroceryArray = ["Cheese", "Milk"];
            // Console.WriteLine(myGroceryArray[0]);

            List<string> myGroceryList = new List<string>();
            myGroceryList.Add("Ice Cream");
            myGroceryList.Add("Coffee");
            // Console.WriteLine(myGroceryList[1]);

            IEnumerable<string> myGroceryEnumerable = new List<string>(); // 

            List<string> mySecondGroceryList = myGroceryEnumerable.ToList();

            int[,] myMultiDimensionalArray =
            {
                {1, 2, 3 },
                {4, 5, 6 },
                {7, 8, 9 }
            };

            // Console.WriteLine(myMultiDimensionalArray[1, 1]);

            Dictionary<string, int> groceryPrices = new Dictionary<string, int>();
            groceryPrices["Cheese"] = 5;

            Console.WriteLine(groceryPrices["Cheese"]);


        }
    }
}