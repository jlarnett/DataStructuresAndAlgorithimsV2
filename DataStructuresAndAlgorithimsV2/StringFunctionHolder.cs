using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2
{
    public static class StringFunctionHolder
    {

        public static bool IsPalindrome(string s)
        {
            //O(n)
            
            var n = s.Length;

            var left = 0;
            var right = n - 1;

            while (left < right)
            {
                if (!char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }
                else if (!char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }
                else
                {
                    if (char.ToLower(s[left]) != char.ToLower(s[right]))
                    {
                        return false;
                    }

                    left++;
                    right--;
                }
            }

            return true;
        }

        public static bool CheckParenthesisAreValid(string s)
        {
            //O(n) Runtime Complexity. 22.6MB memory usage.

            //Check for invalid inputs
            if (s == null || s == string.Empty)
            {
                return true;
            }

            //Create dictionary to check for matching parenthesis values
            Dictionary<char, char> parenthesis = new Dictionary<char, char>();

            //Add the parenthesis using the end parenthesis as the key.
            parenthesis.Add(')', '(');
            parenthesis.Add(']', '[');
            parenthesis.Add('}', '{');

            //Create a stack to store the parenthesis in a LIFO manner Last in first out. 
            Stack<char> stack = new Stack<char>();


            //Loop through all values in the input string
            foreach (var item in s)
            {
                //We check if the item we are on is end parenthesis
                if (item == ')' || item == ']' || item == '}')
                {
                    //We check for items in stack. If items are in stack we verify that the item as top of stack is matching parenthesis
                    //If it matches the dictionary value we remove the parenthesis. If it doesn't match we return false.
                    if (stack.Count > 0 && stack.Peek() == parenthesis[item])
                        stack.Pop();
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    //If item is not ending parenthesis then we push it onto stack.
                    stack.Push(item);
                }
            }

            //Returns whether all parenthesis were ended by algorithm. True == 0, False > 0.
            return stack.Count == 0;
        }




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
