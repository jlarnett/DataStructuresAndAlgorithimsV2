using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2
{
    public static class ArrayAlgorithms
    {
        public static int[] BubbleSort(int[] array)
        {
            /*******************************************************************************************************************
            *   O(n^2) runtime.
            *   Bubble Sort - Works by nesting for loops and comparing values next to each other and swapping the higher upwards. 
            *********************************************************************************************************************/

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            return array;
        }

        public static int[] InsertionSort(int[] array)
        {
            /*******************************************************************************************************************
            *   O(n) runtime at best case -> array is small and close to being sorted
            *   Insertion Sort - Place values in the correct position as you loop through array. 
            *********************************************************************************************************************/

            int length = array.Length;

            for (int i = 1; i < length; ++i)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }

                array[j + 1] = key;
            }

            return array;
        }

        public static int[] SelectionSort(int[] array)
        {
            /*******************************************************************************************************************
            *   O(n^2) runtime.
            *   Selection Sort - Works by finding the smallest value in remaining portion of array and moving it to lowest unsorted index. 
            *********************************************************************************************************************/

            int length = array.Length;

            for (int i = 0; i < length; i++)
            {
                int min = i;
                int temp = array[i];

                for (int j = i + 1; j < length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }

                array[i] = array[min];
                array[min] = temp;

            }

            return array;
        }

        public static int SearchInsertPosition(int[] nums, int target)
        {
            /*******************************************************************************************************************
            *   O(n) runtime.
            *   Returns the position to insert value in a sorted array.
            *   Just loops through array until it finds a value greater than target value to insert. 
            *********************************************************************************************************************/

            for (int i = 0; i < nums.Length; i++)
            {
                //Loops through array
                if (nums[i] >= target)
                {
                    //Checks if the current value is larger than or equal to target. 
                    return i;
                }
            }

            return nums.Length;
        }

        public static int RemoveDuplicateElementsSortedArray(int[] nums)
        {
            /*******************************************************************************************************************
            *   O(n) runtime.
            *   Uses duplicated index & regular index to determine array assignment through loops
            *   keeps track of prev value to compare against current loop value.
            *********************************************************************************************************************/


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

        public static int RemoveElementFromArrayInPlace(int[] nums, int val)
        {
            /*******************************************************************************************************************
            *   O(n) runtime.
            *   Removes element from Array in place.
            *   Uses 2 indexes to control which array elements are assigned and skips assignment when element to remove is found.
            *********************************************************************************************************************/

            //Index that accurate with removed elements
            int slowIndex = 0;

            //General index to iterate through array without change. Always incremented
            int fastIndex = 0;


            //While both indexes are within array length
            while (slowIndex <= nums.Length - 1 && fastIndex <= nums.Length - 1)
            {
                if (nums[fastIndex] != val)
                {
                    //If current value is NOT target value to remove.
                    //Assign basic indexer position value to newArray indexer position
                    //Increment BOTH indexers
                    nums[slowIndex++] = nums[fastIndex++];
                }
                else
                {
                    //If current value == value to be removed
                    //No Assignments, just increment the basic indexer
                    fastIndex++;
                }
            }

            //Return value of slowIndex. E.G. index that mirrors arraySize without removed elements.
            return slowIndex;
        }

        public static bool CheckCommonItems(char[] array1, char[] array2)
        {
            /**********************************************************************************
            *   Give 2 arrays, return bool whether two arrays contain common item.
            *   2 parameters both are arrays. - No Size Limit
            *   Return true or false.
            *
            *   inefficient approach. O(a * b) time complexity.
            *   Double For loop to check array1 against array2
            **********************************************************************************/

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
            /**********************************************************************************
            *   Give 2 arrays, return bool whether two arrays contain common item.
            *   2 parameters both are arrays. - No Size Limit
            *   Return true or false.
            *
            *   O(a + b)
            *   Adds all values in array1 as keys to dictionary. 
            *   Checks array2 values against dictionary to determine if common item exist.
            **********************************************************************************/


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

        public static int[] TwoSum(int[] nums, int target)
        {
            /**********************************************************************************
            *   O(n)
            *   Given int array & target value.
            *   Return index of 2 numbers such they add up to target value.
            *   Each input will have exactly one solution, May not use same element twice.
            **********************************************************************************/

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

        public static int? FirstRecurringElement(int[] characters)
        {
            /*******************************************************************
            *   O(n)
            ********************************************************************/
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
        
        public static int[] MergeSortedArrays(int[] array1, int[] array2, int n1, int n2, int[] arr3)
        {

            /*******************************************************************
            *   O(n)
            ********************************************************************/

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
    }
}
