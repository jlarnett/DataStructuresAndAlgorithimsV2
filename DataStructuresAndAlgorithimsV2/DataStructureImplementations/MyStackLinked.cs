using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2
{
    public class StackNode
    {
        public string Value { get; set; }
        public StackNode Next { get; set; }

        public StackNode(string value)
        {
            this.Value = value;
            this.Next = null;
        }

    }
    class MyStackLinked
    {
        public StackNode top;
        public StackNode bottom;
        public int length;

        public MyStackLinked()
        {
            this.top = null;
            this.bottom = null;
            this.length = 0;
        }

        public string Peek()
        {
            //Check for empty list. 
            if (length > 0)
            {
                //If stack is not empty return top value, but don't remove. 
                return top.Value;
            }

            return null;
        }

        public void Push(string value)
        {
            //Create a newNode with value.
            StackNode newNode = new StackNode(value);

            //Check for empty list. If empty make newNode top & bottom of list. 
            if (length == 0)
            {
                top = newNode;
                bottom = top;
            }
            else
            {
                //Get hold of the top value for changing pointer. 
                StackNode temp = top;

                //Make new top value.
                top = newNode;
                
                //Change the top pointer to the old top node. 
                top.Next = temp;
            }

            this.length++;
        }

        public string Pop()
        {
            //Check for empty null stack
            if (top == null)
            {
                return null;
            }

            //Get hold of the current top value
            StackNode temp = top;

            //Remove the top value from stack by changing top pointer.
            top = top.Next;
            this.length--;

            //Return the top value.
            return temp.Value;
        }

        public void PrintStack()
        {
            while (top != null)
            {
                Console.WriteLine(this.Pop());
            }
        }


    }
}
