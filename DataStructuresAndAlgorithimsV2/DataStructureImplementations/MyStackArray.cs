using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2.DataStructureImplementations
{
    class MyStackArray
    {
        private ArrayList array;

        public MyStackArray()
        {
            array = new ArrayList();
        }

        public string Peek()
        {
            if (array.Count > 0)
            {
                return (string) array[array.Count - 1];
            }

            return null;
        }

        public void Push(string value)
        {
            array.Add(value);
        }

        public string Pop()
        {

            if (array.Count > 0)
            {
                string val = (string)array[array.Count - 1];
                array.RemoveAt(array.Count - 1);

                return val;
            }

            return null;
        }

        public void PrintStack()
        {
            while (array.Count > 0)
            {
                Console.WriteLine(Pop());
            }
        }
    }
}
