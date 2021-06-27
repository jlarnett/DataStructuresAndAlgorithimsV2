using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2
{
    public static class FunctionHolder
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



        public static void ArrayIntro()
        {
            //4 * 4 16 bytes of storage.
            string[] strings = {"a", "b", "c","d"};

            ArrayList strings2 = new ArrayList()
            {
                "a",
                "b",
                "c",
                "d"
            };


            //Access -> O(1)
            var b = strings[2];

            //push -> O(1)
            strings2.Add("e");

            //pop -> 0(1)
            strings2.RemoveAt(strings2.Count - 1);

            //O(n)
            strings2.Insert(0, "a");

            //Dynamic vs Static arrays
            //arraylist = dynamic array

            int[] numbers = new int[50];



        }



        public static void TwitterExerciseFunction()
        {
            //O(1) -> Time Complexity
            //Find 1st, Find Nth...

            Tweet[] array =
            {
                new Tweet() {Message = "Hi", Date = 2012},
                new Tweet() {Message = "My", Date = 2014},
                new Tweet() {Message = "Teddy", Date = 2018}

            };

            string first = array[0].Message;                            //O(1)
            string last = array[array.Length - 1].Message;              //O(1)
        }

        public static bool CheckCommonItems(char[] array1, char[] array2)
        {
            //Give 2 arrays, return bool whether two arrays contain common item.
            //2 parameters both are arrays. - No Size Limit
            //Return true or false.


            //Quick but inefficient approach. O(a * b) time complexity.
            for (int i = 0; i < array1.Length; i++)
            {
               for (int j = 0; j < array2.Length; j++)
               {
                    if (array1[i] == array2[j])
                        return true;
               }
            }

            return false;
        }

        public static bool CheckCommonItems2(char[] array1, char[] array2)
        {
            //Give 2 arrays, return bool whether two arrays contain common item.
            //2 parameters both are arrays. - No Size Limit
            //Return true or false.

            //loop through first array and create object where properties = items in the array.
            //loop through 2nd array and check if item in 2nd array exist on created object.
            //O(a + b)

            Dictionary<char, bool> pairs = new Dictionary<char, bool>();

            for (int i = 0; i < array1.Length; i++)
            {
                if (!pairs.ContainsKey(array1[i]))
                {
                    pairs.Add(array1[i], true);
                }
            }

            for (int i = 0; i < array2.Length; i++)
            {
                if (pairs.ContainsKey(array2[i]))
                {
                    return true;
                }
            }

            return false;

        }

        public static void FindNemo(string[] array)
        {
            // O(n) -> Linear Time
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == "nemo")
                {
                    Console.WriteLine("Found Nemo");
                }
            }
        }

        public static void LogFirstTwoBoxes(int[] boxes)
        {
            // O(1) -> Constant Time
            Console.WriteLine(boxes[0]);
            Console.WriteLine(boxes[1]);
        }

        public static void LogAllPairsOfArray(int[] array)
        {
            // O(n^2) -> Exponential Time
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    Console.WriteLine("Item 1: {0}, Item 2: {1}", array[i], array[j]);
                }
            }
        }

        public static void Booooo(int[] array)
        {
            // O(1) Space Complexity for function.
            for (int i = 0; i < array.Length; i++)      //int i = 1 -> O(1) Space Complexity.
            {
                Console.WriteLine("boooooooo!");
            }
        }

        public static int[] ArrayOfHighNTimes(int[] array)
        {
            // O(n) Space Complexity for function.

            int[] hiArray = new int[] {};

            for (int i = 0; i < array.Length; i++)
            {
                hiArray[i] = array[i];
            }

            return hiArray;
        }
    }
}
