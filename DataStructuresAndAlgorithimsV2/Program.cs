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
            int[] array = {3, 2, 1, 5, 20, 55, 400, 70, 24, 11, 5, 42, 990, 1000, 433, 400};
            PrintArray(array);

            Console.WriteLine();

            int[] sortedArray = ArrayAlgorithms.MergeSortClass.MergeSort(array);
            PrintArray(sortedArray);

            ArrayList newList = new ArrayList();
            newList.Add(5);

        }

        static void PrintArray(int[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i].ToString() + " : ");
            }
        }
    }
}
