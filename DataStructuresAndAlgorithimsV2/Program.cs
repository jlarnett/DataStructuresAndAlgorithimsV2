using System;
using System.Collections;
using System.Diagnostics;
using DataStructuresAndAlgorithimsV2.DataStructureImplementations;

namespace DataStructuresAndAlgorithimsV2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStackArray newStack = new MyStackArray();

            newStack.Push("Discord");
            newStack.Push("Thomas");
            newStack.Push("GreekFreak");

            newStack.PrintStack();
        }
    }
}
