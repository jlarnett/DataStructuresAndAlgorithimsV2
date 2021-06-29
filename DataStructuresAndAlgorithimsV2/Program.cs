using System;
using System.Collections;
using System.Diagnostics;

namespace DataStructuresAndAlgorithimsV2
{
    class Program
    {
        static void Main(string[] args)
        {
            //MergeArrays();
            //HashTables();


            HashTable table = new HashTable(10);
            table.Set("grapes", 1000);
            table.Set("Apples", 50);
            table.Set("Gore", 30);


            foreach (var key in table.Keys())
            {
                Console.WriteLine(key + ": " + table.Get(key));
            }
        }

        static void MergeArrays()
        {
            int[] arr1 = {1, 4, 5, 10, 20};
            int n1 = arr1.Length;

            int[] arr2 = {1, 8, 9, 10, 20};
            int n2 = arr2.Length;

            int[] arr3 = new int[n1 + n2];

            var returnArray = FunctionHolder.MergeSortedArrays(arr1, arr2, n1, n2, arr3);

            for (int i = 0; i < returnArray.Length; i++)
            {
                Console.WriteLine(returnArray[i].ToString());
            }
        }


        static void HashTables()
        {
            Hashtable newTable = new Hashtable();
            newTable.Add("barry", 1);
            newTable.Add("James", 1);


            Console.WriteLine(newTable["barry"]);
            Console.WriteLine(newTable["James"]);
        }

    }
}
