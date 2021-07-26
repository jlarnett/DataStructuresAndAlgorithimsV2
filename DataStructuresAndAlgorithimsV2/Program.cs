using System;
using System.Collections;
using System.Diagnostics;
using DataStructuresAndAlgorithimsV2.DataStructureImplementations;

namespace DataStructuresAndAlgorithimsV2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue newQueue = new MyQueue();
            newQueue.Enqueue("Thomas");
            newQueue.Enqueue("Baker");
            newQueue.Enqueue("Cliff");
            newQueue.Enqueue("Johnson");

            newQueue.PrintQueue();

            Console.WriteLine();

            newQueue.Dequeue();
            newQueue.Dequeue();

            newQueue.PrintQueue();
        }
    }
}
