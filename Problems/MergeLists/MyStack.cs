using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.MergeLists
{
    public class MyStack
    {
        private readonly SinglyLinkedList innerList = new SinglyLinkedList();

        public void Push(int data)
        {
            innerList.Append(data);
        }

        public int Pop()
        {
            var item = innerList.RemoveLast();

            if (item is null)
            {
                throw new InvalidOperationException();
            }

            return item.Data;
        }

        public int Peek()
        {
            var item = innerList.Tail;

            if (item is null)
            {
                throw new InvalidOperationException();
            }

            return item.Data;
        }

        public bool IsEmpty => innerList.Count == 0;
    }
}
