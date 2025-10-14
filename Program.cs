// 23. loops - for, foreach, while, do while
// Demonstrates different ways to iterate over an array and calculate the total value of its elements.

using System;

namespace MyApp
{
    class Program // test

    {
        static void Main(string[] args)
        {
            int[] intsToCompress = { 10, 15, 20, 25, 30, 12, 34 };

            int totalValue = intsToCompress[0] + intsToCompress[1] + intsToCompress[2] +
                             intsToCompress[3] + intsToCompress[4] + intsToCompress[5] +
                             intsToCompress[6];

            Console.WriteLine($"Total Value: {totalValue}"); // Outputs: Total Value: 146    

            totalValue = 0;

            for (int i = 0; i < intsToCompress.Length; i++)
            {
                totalValue += intsToCompress[i];
            }
            Console.WriteLine($"Total Value using loop: {totalValue}"); // Outputs: Total Value using loop: 146


            totalValue = 0;
            foreach (int intForCompression in intsToCompress)
            {
                if (intForCompression > 20)
                {
                    totalValue += intForCompression;
                }

            }
            Console.WriteLine($"Total Value using foreach with if: {totalValue}"); // Outputs: Total Value using foreach with if: 89

            totalValue = 0;

            foreach (int intForCompression in intsToCompress)
            {
                totalValue += intForCompression;
            }
            Console.WriteLine($"Total Value using foreach: {totalValue}"); // Outputs: Total Value using foreach: 146

            int index = 0;
            totalValue = 0;

            while (index < intsToCompress.Length)
            {
                totalValue += intsToCompress[index];
                index++;
            }
            Console.WriteLine($"Total Value using while: {totalValue}"); // Outputs: Total Value using while: 146

            int ind = 0;
            totalValue = 0;

            do
            {
                totalValue += intsToCompress[ind];
                ind++;
            }

            while (ind < intsToCompress.Length); // run then check condition

            Console.WriteLine($"Total Value using do while: {totalValue}"); // Outputs: Total Value using do while: 146

            totalValue = 0;
            totalValue = intsToCompress.Sum();
            Console.WriteLine($"Total Value using LINQ Sum(): {totalValue}"); // Outputs: Total Value using LINQ Sum(): 146

            int[] intsToCompress2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            totalValue = GetSum(intsToCompress2);
            Console.WriteLine($"Total Value using method: {totalValue}"); // Outputs: Total Value using method: 55



        }

        private static int GetSum(int[] intsToCompress)
        {
            int totalValue = 0;
            foreach (int intForCompression in intsToCompress)
            {
                totalValue += intForCompression;
            }
            return totalValue;
        }
    }
}