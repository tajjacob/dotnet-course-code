// 22. Conditional Statements

using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // int myInt = 5;
            // int mySecondInt = 10;

            // if (myInt < mySecondInt)
            // {
            //     myInt += 10;
            // }

            // Console.WriteLine("myInt: " + myInt);

            string myCow = "cow";
            string myCapitalizedCow = "Cow";

            // if (myCow == myCapitalizedCow)
            // {
            //     Console.WriteLine("The strings are equal.");
            // }
            // else
            // {
            //     Console.WriteLine("The strings are not equal.");
            // }

            switch (myCow)
            {
                case "dog":
                    Console.WriteLine("It's a dog.");
                    break;
                case "cat":
                    Console.WriteLine("It's a cat.");
                    break;
                case "cow":
                    Console.WriteLine("It's a cow.");
                    break;
                default:
                    Console.WriteLine("Unknown animal.");
                    break;
            }


        }
    }
}