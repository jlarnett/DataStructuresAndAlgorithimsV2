using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2
{
    public class DNode
    {
        public int Value { get; set; }
        public DNode Next { get; set; }
        public DNode Previous { get; set; }

        public DNode(int value)
        {
            this.Value = value;
            this.Next = null;
            this.Previous = null;
        }


    }

    class DoubleLinkedListed
    {
        private DNode head;
        private DNode tail;

        public int Length { get; set; }

        public DoubleLinkedListed(int value)
        {
            this.head = new DNode(value);
            this.tail = head;

            Length = 1;
        }

        public void Remove(int index)
        {
            index = WrapIndex(index);

            if (index == 0)
            {
                head = head.Next;
                return;
            }

            //Get the leader node && Node to remove
            DNode leader = TraverseToIndex(index - 1);
            DNode nodeToRemove = leader.Next;

            //Change the pointers
            leader.Next = nodeToRemove.Next;
            nodeToRemove.Next.Previous = leader;

            this.Length--;
        }


        public void Insert(int index, int value)
        {
            index = WrapIndex(index);

            if (index == 0)
            {
                Prepend(value);
                return;
            }

            if (index == Length - 1)
            {
                Append(value);
                return;
            }

            DNode newNode = new DNode(value);

            //Gets the Node before index && index node.
            DNode leader = TraverseToIndex(index - 1);
            DNode follower = leader.Next;

            //Handles backwards pointers
            leader.Next = newNode;
            newNode.Previous = leader;

            //Handles fowards pointers
            newNode.Next = follower;
            follower.Previous = newNode;

            //Increments list length.
            this.Length++;
        }


        public void Append(int value)
        {
            DNode newNode = new DNode(value);

            newNode.Previous = this.tail;
            this.tail.Next = newNode;
            this.tail = newNode;

            this.Length++;
        }

        public void Prepend(int value)
        {
            DNode newNode = new DNode(value);

            newNode.Next = this.head;
            this.head.Previous = newNode;

            this.head = newNode;
            this.Length++;
        }

        public void PrintList()
        {
            //O(n)
            if (this.head == null)
            {
                return;
            }
            
            DNode current = this.head;

            while (current != null)
            { 
                Console.Write("-->" + current.Value.ToString());
                current = current.Next;
            }

            Console.WriteLine();
        }

        private DNode TraverseToIndex(int index)
        {
            //O(n)
            //Create base counter
            int counter = 0;

            //Verify index is within list Range
            index = WrapIndex(index);

            //Creates a current node to iterate with. 
            DNode currentNode = head;

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
            return Math.Max(Math.Min(index, this.Length - 1), 0);
        }
    }
}
