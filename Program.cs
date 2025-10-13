// 20. Operators and Conditionals

using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int myInt = 5;
            int mySecondInt = 10;
            // Console.WriteLine(myInt.Equals(mySecondInt)); // False
            // Console.WriteLine(myInt.Equals(mySecondInt / 2)); // True

            // Console.WriteLine(myInt == mySecondInt); // False
            // Console.WriteLine(myInt == mySecondInt / 2); // True
            // Console.WriteLine(myInt != mySecondInt); // True
            Console.WriteLine(myInt > mySecondInt); // False
            Console.WriteLine(myInt < mySecondInt); // True

            Console.WriteLine(5 < 10 && 5 < 20); // True
            Console.WriteLine(5 < 10 && 5 > 20); // False
            Console.WriteLine(5 < 10 || 5 > 20); // True
            Console.WriteLine(!(5 < 10 || 5 > 20)); // False

            // myInt++;

            // Console.WriteLine(myInt);

            // myInt += 7;

            // Console.WriteLine(myInt);

            // myInt -= 8;

            // Console.WriteLine(myInt);

            // Console.WriteLine(myInt * mySecondInt);
            // Console.WriteLine(myInt / mySecondInt);
            // // Console.WriteLine(myInt + mySecondInt);

            // Console.WriteLine(5 + 5 * 2); // 15
            // Console.WriteLine((5 + 5) * 2); // 20

            // Console.WriteLine(Math.Pow(5, 2)); // 25
            // Console.WriteLine(Math.Sqrt(25)); // 5

            // string myString = "test";

            // Console.WriteLine(myString);
            // myString += ". second test.";
            // Console.WriteLine(myString);

            // myString = myString + " third test.";
            // Console.WriteLine(myString);

            // string[] myStringArray = myString.Split(". ");

            // Console.WriteLine(myStringArray[0]);
            // Console.WriteLine(myStringArray[1]);
            // Console.WriteLine(myStringArray[2]);



        }
    }
}