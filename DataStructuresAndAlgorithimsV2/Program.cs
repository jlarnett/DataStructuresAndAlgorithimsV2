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
            int result = RecursiveAlgorithms.FindFactorialRecursive(10);
            Console.WriteLine(result.ToString());

            int result2 = RecursiveAlgorithms.FindFactorialIteratively(10);
            Console.WriteLine(result2.ToString());
        }
    }
}
