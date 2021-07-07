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
    }
}
