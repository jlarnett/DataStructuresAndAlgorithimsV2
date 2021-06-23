using System;
using System.Diagnostics;

namespace DataStructuresAndAlgorithimsV2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nemo = {"nemo"};
            string[] everyone = {"net", "Squirt", "jacob", "Josh", "nigel", "nemo" };
            string[] largeArray = new string[100000];

            //Array.Fill(largeArray, "nemo");
            //FindNemo(largeArray);

            int[] boxes = {1, 2, 3, 4, 5};
            LogFirstTwoBoxes(boxes);

            int[] boxes2 = {1, 2, 3, 4, 5};
            LogAllPairsOfArray(boxes2);
        }

        public static void FindNemo(string[] array)
        {
            // O(n) -> Linear Time
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == "nemo")
                {
                    Console.WriteLine("Found Nemo");
                }
            }
        }

        public static void LogFirstTwoBoxes(int[] boxes)
        {
            // O(1) -> Constant Time
            Console.WriteLine(boxes[0]);
            Console.WriteLine(boxes[1]);
        }

        public static void LogAllPairsOfArray(int[] array)
        {
            // O(n^2) -> Exponential Time
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    Console.WriteLine("Item 1: {0}, Item 2: {1}", array[i], array[j]);
                }
            }
        }


    }
}
