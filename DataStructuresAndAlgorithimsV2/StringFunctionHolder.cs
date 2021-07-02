using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2
{
    public static class StringFunctionHolder
    {
        public static string ReverseString(string incomingString)
        {
            //Reverses string without converting to array directly.
            //O(n)
            string result = String.Empty;

            for (int i = incomingString.Length - 1; i >= 0; i--)
            {
                result += incomingString[i];
            }

            return result;
        }

        public static string ReverseString2(string incomingString)
        {
            //Built in C# way to reverse strings after converting to array.
            char[] chars = incomingString.ToCharArray();
            Array.Reverse(chars);

            return new string(chars);
        }

        public static int RomanToInt(string s)
        {
            Dictionary<char, int> RomanMap = new Dictionary<char, int>()
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };
        
            int number = 0;

            //Loops through Roman numeral string
            for (int i = 0; i < s.Length; i++)
            {
                //Checks whether the roman[i] value is < roman[i +1]. If it is it does the pre-subtraction before moving on to next roman numeral as normal..
                if (i + 1 < s.Length && RomanMap[s[i]] < RomanMap[s[i + 1]])
                {
                    number -= RomanMap[s[i]];
                }
                else
                {
                    //If next number is smaller than it simply adds to total number
                    number += RomanMap[s[i]];
                }
            }
        
            return number;
        }
    }
}
