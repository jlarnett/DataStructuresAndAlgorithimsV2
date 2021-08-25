using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2
{
    public static class ArrayAlgorithms
    {

        public static class MergeSortClass
        {
            public static int[] MergeSort(int[] array)
            {

                /*******************************************************************************************************************
                *   O(n Log n) runtime.
                *   Merge Sort - Breaks the arrays into smaller components. then merges & compares them recursively. 
                *********************************************************************************************************************/


                //Define array variables
                int[] left;
                int[] right;

                int[] result = new int[array.Length];


                //Recursive base case to avoid infinite recursion
                if (array.Length <= 1)
                    return array;


                //Get point of division among array. Declare the size of left array. 
                int midPoint = array.Length / 2;
                left = new int[midPoint];


                if (array.Length % 2 == 0)
                {
                    //Checks if array size is divisible by 2. Determines right side size of array. 
                    right = new int[midPoint];
                }
                else
                {
                    //Adds 1 to account for full array size if not divisible by 2. 
                    right = new int[midPoint + 1];
                }

                for (int i = 0; i < midPoint; i++)
                {
                    //left portion of array assignment
                    left[i] = array[i];
                }

                int x = 0;         //x is incrementer for right array. Cant use loop variable because it has to start at midpoint

                for (int i = midPoint; i < array.Length; i++)
                {
                    //right portion of array assignment. 
                    right[x] = array[i];
                    x++;
                }

                //Pass the 2 halfs of the arrays recursively to this method. 
                left = MergeSort(left);
                right = MergeSort(right);


                //Calls the merge method. Which handles comparison of arrays larger than 1.
                result = Merge(left, right);

                return result;
            }

            private static int[] Merge(int[] left, int[] right)
            {
                //Get result array size & Define array.
                int resultLength = right.Length + left.Length;
                int[] result = new int[resultLength];

                //Define iterators for all arrays. 
                int indexLeft = 0, indexRight = 0, indexResult = 0;

                while (indexLeft < left.Length ||indexRight < right.Length)
                {
                    //While left or right iterators are still within array range. 

                    if (indexLeft < left.Length && indexRight < right.Length)
                    {
                        //If both arrays still have values in them. 
                        if (left[indexLeft] <= right[indexRight])
                        {
                            //left array value is greater than right array value assign left to result array
                            result[indexResult] = left[indexLeft];
                            indexLeft++;
                            indexResult++;
                        }
                        else
                        {
                            result[indexResult] = right[indexRight];
                            indexRight++;
                            indexResult++;
                        }
                    }

                    else if (indexLeft < left.Length)
                    {
                        //Assuming only left array values are left. No comparison just assign remaining since already sorted. 
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else if (indexRight < right.Length)
                    {
                        //Assuming only right array values are left. No comparison just assign remaining since arrays should already by sorted.
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }

                return result;
            }
        }

        public static string LongestCommonPrefix(string[] strs)
        {

            /*******************************************************************************************************************
            *   O(n^2) Runtime? Possibly O(n)
            *   Given a array of strings. Finds the longest prefix that all strings in array contains. 
            *********************************************************************************************************************/

            //If only on item in array return the entire string.
            if (strs.Length == 1)
            {
                return strs[0];
            }


            var prefixString = "";

            //Iterate over the length of the first string in array.
            for (int i = 0; i < strs[0].Length; i++)
            {

                foreach (string str in strs)
                {
                    //If iteration of first string is longer than any word in array. prefix is finished. 
                    if (i > str.Length - 1)
                    {
                        return prefixString;
                    }


                    //If the first array items character != the current strings character. Return prefix. 
                    if (strs[0][i] != str[i])
                    {
                        return prefixString;
                    }
                }

                prefixString += strs[0][i];
            }


            return prefixString;
        }

        public class ListNode 
        {
            public int val;
            public ListNode next;

            public ListNode(int val=0, ListNode next=null) 
            {
                this.val = val;
                this.next = next;
            }
        }


        public static ListNode DeleteDuplicatesFromSortedList(ListNode head)
        {

            /*******************************************************************************************************************
            *   O(n) runtime.
            *   Deletes duplicates from sorted singly linked list. Basically checks the first value against second and changes pointer if same
            *********************************************************************************************************************/


            //We create a currentNode
            var node = head;

            //Check for null value as loop progresses
            while (node != null)
            {
                //If the value of the node & node.next are the same. its duplicate since its a sorted list. 
                if ((node.next != null) && (node.next.val == node.val))
                {
                    //change the currentNodes pointer.
                    node.next = node.next.next;
                }
                else
                {
                    //Otherwise iterate the node. This only happens during the else to guarantee multiple duplicates are caught. 
                    node = node.next;
                }
            }

            return head;
        }




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

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {

            /*******************************************************************
            *   O(n) Time Complexity
            *   Receiving two linked list. Add the numbers at each position
            *   
            ********************************************************************/

            var carry = 0;

            var dummy = new ListNode(-1);
            var cur = dummy;

            while (l1 != null || l2 != null || carry != 0)
            {
                var l1Number = l1 != null ? l1.val : 0;
                var l2Number = l2 != null ? l2.val : 0;


                var oneResult = l1Number + l2Number + carry;

                cur.next = new ListNode(oneResult % 10);
                carry = oneResult / 10;

                cur = cur.next;

                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }

            var head = dummy.next;
            dummy.next = null;

            return head;
        }

        public static int[] PlusOne(int[] digits)
        {
            /*******************************************************************
            *   O(n) Time Complexity
            *   Adds one to the final digit in array. Assuming the array is a integer value. 
            ********************************************************************/

            int carrier = 1;

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                //Adds 1 to the last value. Propagates the carry up the number if required.  
                int temp = digits[i] + carrier;

                digits[i] = temp % 10;
                carrier = temp / 10;
            }

            if (carrier == 1)
            {
                //This happens when the entire number has carry. Puts carry at front. then adds array digits to list. 
                List<int> temp = new List<int>();

                temp.Add(carrier);

                foreach (var n in digits)
                {
                    temp.Add(n);
                }

                return temp.ToArray();
            }

            return digits;
        }

        public static int LengthOfLastWord(string s)
        {
            /*******************************************************************
            *   O(n) Time Complexity
            *   Returns the length of last word in string.
            *   Checks for the first space when iterating backwards. 
            ********************************************************************/

            int length = 0;

            for (int i = s.Length; i >= 0; i--)
            {
                if (s[i] == ' ')
                {
                    if (length == 0)
                    {
                        continue;
                    }
                    else
                    {
                        return length;
                    }
                }

                length++;
            }

            return length;
        }

        public static int SingleNumber(int[] nums)
        {
            /*******************************************************************
            *   O(n) Time Complexity
            *   Finds the single number if given array of pair digits and one single digit. 
            ********************************************************************/

            var singleNumber = 0;

            foreach (var num in nums)
            {
                singleNumber ^= num;
            }

            return singleNumber;

        }

        public static int SingleNumber2(int[] nums) 
        {
            /*******************************************************************
            *   O(n) Time Complexity
            *   Finds the single number if given array of pair digits and one single digit.
            *   Uses hashset.
            ********************************************************************/
            var hashSet = new HashSet<int>();
        
            for(int i = 0; i < nums.Length; ++i)
            {
                if(hashSet.Contains(nums[i]))
                {
                    hashSet.Remove(nums[i]);
                }
                else
                {
                    hashSet.Add(nums[i]);
                }
            }
            return hashSet.ElementAt(0);
        }

    }
}
