using System;
using System.Collections;
using System.Collections.Generic;

namespace Trees
{
    public enum TraverseOrder
    {
        InOrder,
        PreOrder,
        PostOrder,
        LevelOrder
    }

    public class Tree<T> 
        where T: IComparable<T>
    {
        private Node<T> _root;

        public Tree() : this(null) {}

        public Tree(T rootData) : this(new Node<T>(rootData)) {}

        internal Tree(Node<T> root)
        {
            _root = root;
        }

        public bool IsEmpty => _root == null;

        public void Insert(T data)
        {
            if (_root == null)
            {
                _root = new Node<T>(data);
                return;
            }

            _root.Insert(data);
        }

        public IEnumerable<T> Traverse()
        {
            return Traverse(TraverseOrder.InOrder);
        }

        public IEnumerable<T> Traverse(TraverseOrder order)
        {
            if(_root == null)
                throw new InvalidOperationException(); 

            var traversal = default(IEnumerable<T>);

            switch(order) 
            {
                case TraverseOrder.InOrder:
                    traversal = _root.TraverseInOrder();
                    break;
                case TraverseOrder.PostOrder:
                    traversal = _root.TraversePostOrder();
                    break;
                case TraverseOrder.PreOrder:
                    traversal = _root.TraversePreOrder();
                    break;
                case TraverseOrder.LevelOrder:
                    traversal = _root.TraverseLevelOrder();
                    break;
            }

            return traversal;
        }

        internal Node<T> Root => _root;
    }
}