using System;
using System.Diagnostics;

namespace DataStructuresAndAlgorithimsV2
{
    class Program
    {
        static void Main(string[] args)
        {
            var containedCommonItem = FunctionHolder.CheckCommonItems2(new[] {'n', 'b', 'c'}, new[] {'c', 'a', 'j', 'l'});
            Console.WriteLine(containedCommonItem);
        }

    }
}
