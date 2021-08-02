using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2.Algorithms
{
    public static class RecursiveAlgorithms
    {
        public static int FindFactorialRecursive(int number)
        {
            if (number == 1)
            {
                return 1;
            }

            return number * FindFactorialRecursive(number - 1);
        }

        public static int FindFactorialIteratively(int number)
        {
            int result = 1;

            for (int i = number; i > 0; i--)
            {
                result *= i;
            }

            return result;
        }

        public static int FibonacciRecursively(int n)
        {
            /********************************************************************************
            *   O(2^N)
            *********************************************************************************/
            if (n < 2)
            {
                return n;
            }

            return FibonacciRecursively(n - 1) + FindFactorialRecursive(n - 2);
        }

        public static int FibonacciRecursivelyEfficient(int n, int val, int prev)
        {
            /**********************************************************************************
            *   O(n)
            **********************************************************************************/
            if (n == 0)
            {
                return prev;
            }

            if (n == 1)
            {
                return val;
            }

            return FibonacciRecursivelyEfficient(n - 1, val + prev, val);
        }

        public static int FibonacciIteratively(int n)
        {
            /**********************************************************************************
            *   O(n)
            **********************************************************************************/
            int result = 1;
            int lastNumber = 0;
            int temp;

            if (n == 0)
            {
                return 0;
            }

            for (int i = 1; i < n; i++)
            {
                temp = result;
                result += lastNumber;
                lastNumber = temp;
            }
            return result;
        }
    }
}
