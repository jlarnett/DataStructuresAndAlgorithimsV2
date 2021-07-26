using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2.DataStructureImplementations
{
    class MyQueueStack
    {
        //Base Stack. Used to store the items originally. 
        private Stack<string> stack = new Stack<string>();

        //Used to reverse the top stack, anytime the bottom value of base stack is needed. 
        private Stack<string> auxiliaryStack = new Stack<string>();

        public string Peek()
        {
            //Reverses the stack to aux stack, then gets the top value, then reverses aux stack back to normal stack again. 
            FillAuxiliaryStackWithStack();

            string value = auxiliaryStack.Peek();
            FillStackWithAuxiliaryStack();

            return value;
        }

        public void Enqueue(string value)
        {
            this.stack.Push(value);
        }

        public string Dequeue()
        {
            //Reverse the stack to aux stack. Pop it to get the front value of normal stack. Reverse back after popping. 
            FillAuxiliaryStackWithStack();
            string value = auxiliaryStack.Pop();

            FillStackWithAuxiliaryStack();
            return value;
        }

        private void FillAuxiliaryStackWithStack()
        {
            //Pushes all items from stack to auxiliary stack. 
            while (stack.Count > 0)
            {
                auxiliaryStack.Push(stack.Pop());
            }
        }

        private void FillStackWithAuxiliaryStack()
        {
            //pushes all items from auxiliary stack to regular stack
            while (auxiliaryStack.Count > 0)
            {
                stack.Push(auxiliaryStack.Pop());
            }
        }

        public void PrintQueue()
        {
            //Check for edge case.
            if (stack.Count == 0)
            {
                return;
            }

            //Reverse stack to get proper order. 
            FillAuxiliaryStackWithStack();

            //Print all members in queue in order
            foreach (var item in auxiliaryStack)
            {
                Console.WriteLine(" --> " + item);
            }

            Console.WriteLine();

            //reverse back to normal stack order. 
            FillStackWithAuxiliaryStack();
        }



    }
}
