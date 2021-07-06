using System;
using System.Collections;
using System.Diagnostics;

namespace DataStructuresAndAlgorithimsV2
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList newList = new LinkedList(20);
            newList.Append(45);
            newList.Prepend(15);

            newList.PrintList();
        }
    }
}
