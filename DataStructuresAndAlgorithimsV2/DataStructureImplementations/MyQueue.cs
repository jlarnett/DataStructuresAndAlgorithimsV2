using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2.DataStructureImplementations
{
    public class QueueNode
    {
        public string Value { get; set; }
        public QueueNode Next { get; set; }

        public QueueNode(string value)
        {
            this.Value = value;
        }
    }
    class MyQueue
    {
        public QueueNode first;
        public QueueNode last;
        public int length;

        public MyQueue()
        {
            first = null;
            last = null;
            length = 0;
        }

        public string Peek()
        {
            if (length > 0)
            {
                return first.Value;
            }

            return null;
        }

        public void Enqueue(string value)
        {
            QueueNode newNode = new QueueNode(value);

            if (length == 0)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                last.Next = newNode;
                last = newNode;
            }

            length++;
        }

        public string Dequeue()
        {
            if (first == null)
            {
                return null;
            }

            if (this.length == 0)
            {
                last = null;
            }

            QueueNode temp = first; 

            first = first.Next;
            length--; 

            return temp.Value;
        }

        public void PrintQueue()
        {
            if (first == null)
            {
                return;
            }

            QueueNode currentNode = first;

            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }

            Console.WriteLine();
        }
    }
}
