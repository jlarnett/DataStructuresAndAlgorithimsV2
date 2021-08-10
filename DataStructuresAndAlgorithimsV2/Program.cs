using System;
using System.Collections;
using System.Diagnostics;
using DataStructuresAndAlgorithimsV2.Algorithms;
using DataStructuresAndAlgorithimsV2.DataStructureImplementations;

namespace DataStructuresAndAlgorithimsV2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {3, 209, 40, 99, 100, 55, 32, 44, 95};
            var sortedArray = ArrayAlgorithms.InsertionSort(array);

            PrintArray(sortedArray);
        }

        static void PrintArray(int[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].ToString());
            }
        }
    }
}
