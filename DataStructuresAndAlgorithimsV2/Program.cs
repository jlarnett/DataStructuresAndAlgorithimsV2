using System;
using System.Diagnostics;

namespace DataStructuresAndAlgorithimsV2
{
    class Program
    {
        static void Main(string[] args)
        {
            var val = FunctionHolder.ReverseString("This is a string to reverse");
            Console.WriteLine(val);

            var val2 = FunctionHolder.ReverseString2("Test String");
            Console.WriteLine(val2);
        }
    }
}
