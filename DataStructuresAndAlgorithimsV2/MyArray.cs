using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithimsV2
{
    class MyArray
    {
        //This is a from scratch array implementation. Modified a bit for C#

        public int Length { get; set; }
        private Object[] data;

        public MyArray()
        {
            this.Length = 0;
            this.data = new object[1];
        }

        public Object Get(int index)
        {
            //returns the value at specified index.
            return this.data[index];
        }

        public Object Push(Object newObj)
        {
            if (this.data.Length == this.Length)
            {
                Object[] temp = new object[this.Length];
                Array.Copy(this.data, temp, Length);

                this.data = new object[Length + 1];
                Array.Copy(temp, this.data, Length);
            }

            //Adds object to the end of array.
            this.data[this.Length] = newObj;
            this.Length++;

            return this.data;
        }

        public Object Pop()
        {
            //removes the last item from array and returns it. 
            var lastItem = this.data[Length - 1];
            this.data[Length - 1] = null;
            this.Length--;
            return lastItem;
        }

        public Object Delete(int index)
        {
            //
            var itemToDelete = this.data[index];
            ShiftItems(index);

            return itemToDelete;
        }

        private void ShiftItems(int index)
        {
            //Takes the index and iterates from index -> End of array.
            for (int i = index; i < this.Length - 1; i++)
            {
                //Assign all values 1 spot lower.
                this.data[i] = this.data[i + 1];
            }

            this.data[this.Length - 1] = null;
            this.Length--;
        }
    }
}
