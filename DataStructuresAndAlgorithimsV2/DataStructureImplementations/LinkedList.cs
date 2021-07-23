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
            //O(1)
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
            //O(1)
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
            //O(n)
            //Get index within list range. 
            index = WrapIndex(index);

            //If the index is beginning of list. Prepend
            if (index == 0)
            {
                Prepend(value);
                return;
            }

            //If the index is end of list. Append
            if (index == length - 1)
            {
                Append(value);
                return;
            }

            //Create a new node to insert into list. 
            Node newNode = new Node(value);

            //Get access to Node before index to insert at. 
            Node leader = TraverseToIndex(index - 1);

            //Create a node holdingPointer = leaderNode.Next
            Node holdingPointer = leader.Next;

            //
            leader.Next = newNode;
            newNode.Next = holdingPointer;

            this.length++;
        }

        public void Remove(int index)
        {
            //O(n)
            //Get index within list range.
            index = WrapIndex(index);

            //Check if index is head of list. 
            if (index == 0)
            {
                //Move the head forward one node.
                head = head.Next;
                return;
            }

            //Get the Node prior to index
            Node leader = TraverseToIndex(index - 1);

            //Get a pointer to the node to remove so we have reference to its next node.
            Node nodeToRemove = leader.Next;
            
            //Change the leader's pointer past the NodeToRemove.
            leader.Next = nodeToRemove.Next;


            //Decrement List. 
            this.length--;
        }

        public void Reverse()
        {
            //Check for single item in list.
            if (this.head.Next == null)
            {
                return;
            }

            //reference to head.
            Node first = head;

            //Reference to second item in list.
            Node second = first.Next;

            tail = head;


            while (second != null)
            {
                Node temp = second.Next;
                second.Next = first;

                first = second;
                second = temp;

            }

            head.Next = null;
            head = first;

        }

        public void PrintList()
        {
            //O(n)
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
            //O(n)
            //Create base counter
            int counter = 0;

            //Verify index is within list Range
            index = WrapIndex(index);

            //Creates a current node to iterate with. 
            Node currentNode = head;

            //While the base counter hasn't reached index e.g. 
            while (counter != index)
            {
                currentNode = currentNode.Next;
                counter++;
            }

            //Once index is reached. return the current Node.
            return currentNode;
        }

        private int WrapIndex(int index)
        {
            //Returns the correct index, but limits the start to 0 and End to List length - 1;
            return Math.Max(Math.Min(index, this.length - 1), 0);
        }

    }
}
