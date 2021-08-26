using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2.Algorithms
{
    class Fibonacci_DP
    {

        /*******************************************************************
*   O(n) Time Complexity
*   Finds the single number if given array of pair digits and one single digit. 
********************************************************************/


        private static Dictionary<int, int> cache = new Dictionary<int, int>();

        public static int FibonacciMaster(int n)
        {
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            if (n < 2)
            {
                return n;
            }

            cache.Add(n, FibonacciMaster(n - 1) + FibonacciMaster(n - 2));
            return cache[n];
        }

    }
}
