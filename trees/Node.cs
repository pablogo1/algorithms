using System;
using System.Collections.Generic;

namespace Trees
{
    internal class Node<T> where T: IComparable<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        internal Node(T data)
        {
            Data = data;
        }

        public void Insert(T data) 
        {
            var comparision = data.CompareTo(this.Data);

            if(comparision <= 0) 
            {
                if(Left == null)
                    Left = new Node<T>(data);
                else 
                    Left.Insert(data);
            } else 
            {
                if(Right == null)
                    Right = new Node<T>(data);
                else
                    Right.Insert(data);
            }
        }

        internal IEnumerable<T> TraverseInOrder()
        {
            var list = new List<T>();

            if(Left != null)
                list.AddRange(Left.TraverseInOrder());

            list.Add(this.Data);

            if(Right != null)
                list.AddRange(Right.TraverseInOrder());

            return list;
        }

        internal IEnumerable<T> TraversePostOrder()
        {
            var list = new List<T>();

            if(Left != null)
                list.AddRange(Left.TraversePostOrder());

            if(Right != null)
                list.AddRange(Right.TraversePostOrder());

            list.Add(this.Data);
            
            return list;
        }

        internal IEnumerable<T> TraversePreOrder()
        {
            var list = new List<T>();

            list.Add(this.Data);
            
            if(Left != null)
                list.AddRange(Left.TraversePreOrder());

            if(Right != null)
                list.AddRange(Right.TraversePreOrder());

            return list;
        }
    }
}