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
    public static class ExampleFunctionHolder
    {

        public static void LinkedListExample()
        {
            LinkedList<string> list = new LinkedList<string>();

            list.AddFirst(new LinkedListNode<string>("Grape"));
            list.AddLast(new LinkedListNode<string>("Pair"));

            LinkedListNode<string> current = list.Find("Grape");
            list.AddBefore(current, "Lemon");


            foreach (var node in list)
            {
                Console.WriteLine(node.ToString());
            }
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
