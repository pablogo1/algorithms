using System;
using System.IO;
using System.Text;

namespace Problems.MergeLists
{
    public class SinglyLinkedList
    {
        public SinglyLinkedListNode Head { get; private set; } = null;
        public SinglyLinkedListNode Tail { get; private set; } = null;

        public int Count { get; private set; } = 0;

        public void Append(int nodeData)
        {
            var newNode = new SinglyLinkedListNode(nodeData);

            if (Head == null)
            {
                Head = newNode;
            } else
            {
                Tail.Next = newNode;
            }

            Tail = newNode;
            Count++;
        }

        public void Prepend(int nodeData)
        {
            var newNode = new SinglyLinkedListNode(nodeData);

        }

        public SinglyLinkedListNode RemoveFirst()
        {
            throw new NotImplementedException();
        }

        public SinglyLinkedListNode RemoveLast()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object other)
        {
            if (!(other is SinglyLinkedList))
            {
                return false;
            }

            var ptr1 = this.Head;
            var ptr2 = (other as SinglyLinkedList).Head;

            while (ptr1 != null && ptr2 != null)
            {
                if (ptr1.Data != ptr2.Data)
                {
                    return false;
                }
                ptr1 = ptr1.Next;
                ptr2 = ptr2.Next;
            }

            if (ptr1 != null || ptr2 != null)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return 7 ^ Head.GetHashCode() ^ Tail.GetHashCode();
        }

        public static SinglyLinkedList FromArray(int[] array)
        {
            var newList = new SinglyLinkedList();

            foreach (int item in array)
            {
                newList.Append(item);
            }

            return newList;
        }

        public static void Print(SinglyLinkedListNode head, string sep, TextWriter textWriter)
        {
            var node = head;
            textWriter.Write("[");

            while (node != null)
            {
                textWriter.Write("{0}", node.Data);

                if (node.Next != null)
                {
                    textWriter.Write(sep);
                }

                node = node.Next;
            }

            textWriter.Write("]");
        }
    }
}
