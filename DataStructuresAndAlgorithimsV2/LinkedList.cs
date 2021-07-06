using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2
{

    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value)
        {
            this.Value = value;
            this.Next = null;
        }
    }

    public class LinkedList
    {
        private Node head;
        private Node tail;
        private int length;

        public LinkedList(int value)
        {
            this.head = new Node(value);
            this.tail = this.head;
            this.length = 1;
        }

        public void Append(int value)
        {
            //Instantiate a new node.
            Node newNode = new Node(value);

            //Take the current tail and assign its next pointer to newNode;
            this.tail.Next = newNode;

            //Make tail = newNode;
            this.tail = newNode;

            //Increment length value;
            this.length++;
        }

        public void Prepend(int value)
        {
            //Create New node
            Node newNode = new Node(value);

            //Assign the newNodes next pointer = to the current head.
            newNode.Next = this.head;

            //Make the head = newNode
            this.head = newNode;
            
            //Increment length Value
            this.length++;
        }

        public void Insert(int index, int value)
        {
            index = WrapIndex(index);

            if (index == 0)
            {
                Prepend(value);
                return;
            }

            if (index == length - 1)
            {
                Append(value);
                return;
            }

            Node newNode = new Node(value);

            Node leader = TraverseToIndex(index - 1);
            Node holdingPointer = leader.Next;

            leader.Next = newNode;
            newNode.Next = holdingPointer;

            this.length++;
        }

        public void PrintList()
        {
            if (this.head == null)
            {
                return;
            }

            Node current = this.head;

            while (current != null)
            { 
                Console.Write("-->" + current.Value.ToString());
                current = current.Next;
            }

            Console.WriteLine();
        }

        private Node TraverseToIndex(int index)
        {
            int counter = 0;

            index = WrapIndex(index);
            Node currentNode = head;

            while (counter != index)
            {
                currentNode = currentNode.Next;
                counter++;
            }

            return currentNode;
        }

        private int WrapIndex(int index)
        {
            return Math.Max(Math.Min(index, this.length - 1), 0);
        }

    }
}
