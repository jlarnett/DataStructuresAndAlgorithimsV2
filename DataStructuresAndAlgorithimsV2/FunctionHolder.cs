using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2
{
    public static class FunctionHolder
    {
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


        public static int RemoveDuplicateElementsSortedArray(int[] nums)
        {
            //O(n)
            //Check for invalid inputs
            if(nums == null || nums.Length == 0)
                return 0;
        
            //Create indexes to help with tracking array position for duplicated values.
            int duplicated = 0;
            int prev = int.MinValue;
            int idx = 0;

            foreach(int item in nums)
            {
                //Checks if prev value == to the current value.
                if(prev == item)
                {
                    //If item is duplicated increase duplicated indexer
                    duplicated++;
                }   
            
                //assign the item to the correct index using duplicated indexer to track index difference.
                nums[idx - duplicated] = item;
            
                //Assign prev = current item before iterating
                prev = item;

                //increment indexer.
                idx++;
            }
        
            return nums.Length - duplicated;
        }



        public static int[] MergeSortedArrays(int[] array1, int[] array2, int n1, int n2, int[] arr3)
        {
            //i array 1 iterator
            int i = 0;

            //j array 2 iterator
            int j = 0;

            //k array 3 iterator -> output array iterator.
            int k = 0;


            while (i < n1 && j < n2)
            {

                //While we can compare array elements to each other. E.G. since sorted array there is a reason to compare
                if (array1[i] < array2[j])
                {
                    //array1 item < array2 item -> Add array1 item to output array.
                    //Increment output array & array 1

                    arr3[k] = array1[i];
                    k++;
                    i++;
                }
                else
                {

                    //array 2 item < array1 item -> Add array2 item to output array.
                    //Increment output array & array 2
                    arr3[k] = array2[j];
                    k++;
                    j++;
                }
            }

            while (i < n1)
            {
                //After one of the arrays iterators is out of bounds. Figure out which one then add remaining elements to output array.
                arr3[k] = array1[i];
                k++;
                i++;
            }

            while (j < n2)
            {
                //After one of the arrays iterators is out of bounds. Figure out which one then add remaining elements to output array.
                arr3[k] = array2[j];
                k++;
                j++;
            }

            return arr3;
        }

        public static int? FirstRecurringElement(int[] characters)
        {
            HashSet<int> chars = new HashSet<int>();

            for (int i = 0; i < characters.Length; i++)
            {
                if (chars.Contains(characters[i]))
                {
                    return characters[i];
                }

                chars.Add(characters[i]);
            }

            return null;
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            //O(n)
            //Given int array & target value. 
            //Return index of 2 numbers such they add up to target value.
            //Each input will have exactly one solution, May not use same element twice.

            //Create a dictionary to hold values and index
            var numsDictionary = new Dictionary<int, int>();

            //Loops through input array.
            for (int i = 0; i < nums.Length; i++)
            {
                //Get number form array.
                int num = nums[i];

                //check if num is greater than target.
                if (num > target)
                    continue;

                //Check the dictionary for the complementary number to num. If it finds the complementary value key returns index of it.
                if (numsDictionary.TryGetValue(target - num, out int index))
                {
                    //Returns the current loop index & Found complementary number index.
                    return new[] {index, i};
                }

                //If loop couldn't find complementary number for rotation then adds the current number and index to dictionary.
                numsDictionary[num] = i;
            }

            return null;
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


            //inefficient approach. O(a * b) time complexity.
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
