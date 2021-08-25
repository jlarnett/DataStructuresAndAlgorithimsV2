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
            int[] newArray = new[] {2, 2, 4, 4, 5, 9, 9, 10, 10};
            Console.WriteLine(ArrayAlgorithms.SingleNumber(newArray));
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
