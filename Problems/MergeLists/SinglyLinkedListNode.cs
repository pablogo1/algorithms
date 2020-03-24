using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Problems.MergeLists
{
    public class SinglyLinkedListNode
    {
        public SinglyLinkedListNode(int data)
        {
            this.Data = data;
        }

        public int Data { get; set; }
        public SinglyLinkedListNode Next { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is SinglyLinkedListNode)
            {
                return this.Data == this.Data;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return 7 ^ Data.GetHashCode();
        }
    }
}
