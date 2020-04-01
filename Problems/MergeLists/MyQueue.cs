using System;

namespace Problems.MergeLists
{
    public class MyQueue
    {
        private const string ERR_QUEUE_EMPTY = "Queue is empty.";
        private readonly SinglyLinkedList innerList = new SinglyLinkedList();

        public bool IsEmpty => innerList.Count == 0;

        public void Enqueue(int data)
        {
            innerList.Append(data);
        }

        public int Dequeue()
        {
            var item = innerList.RemoveFirst();

            if (item is null)
                throw new InvalidOperationException(ERR_QUEUE_EMPTY);

            return item.Data;
        }

        public int Peek()
        {
            var item = innerList.Head;

            if (item is null)
                throw new InvalidOperationException(ERR_QUEUE_EMPTY);

            return item.Data;
        }
    }
}
