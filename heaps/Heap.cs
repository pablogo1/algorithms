using System;

namespace Heaps
{
    public abstract class Heap
    {
        private int _capacity;
        private int _size;
        private int[] _items;

        public Heap() : this(10) {}

        public Heap(int initialCapacity) 
        {
            _capacity = initialCapacity;
            _size = 0;
            _items = new int[_capacity];
        }

        protected int Capacity => _capacity;
        protected int Size => _size;
        protected int[] Items => _items;

        protected bool IsEmpty => _size == 0;
        
        protected abstract bool Compare(int a, int b);

        private int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
        private int GetRightChildIndex(int parentIndex) => 2 * (parentIndex + 1);
        private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;

        private bool HasLeftChild(int index) => GetLeftChildIndex(index) < _size;
        private bool HasRightChild(int index) => GetRightChildIndex(index) < _size;
        private bool HasParent(int index) => GetParentIndex(index) >= 0;

        private int GetLeftChild(int index) => _items[GetLeftChildIndex(index)];
        private int GetRightChild(int index) => _items[GetRightChildIndex(index)];
        private int GetParent(int index) => _items[GetParentIndex(index)];
        
        private void Swap(int indexA, int indexB) 
        {
            int temp = _items[indexA];
            _items[indexA] = _items[indexB];
            _items[indexB] = temp;
        }

        private void EnsureCapacity()
        {
            if(_size == _capacity) 
            {
                _capacity *= 2;
                Array.Resize(ref _items, _capacity);
            }
        }

        private void HeapifyUp()
        {
            int index = _size - 1;
            // while(HasParent(index) && GetParent(index) > _items[index]) 
            while(HasParent(index) && !Compare(GetParent(index), _items[index]))
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }

        private void HeapifyDown(int index = 0)
        {
            while(HasLeftChild(index)) 
            {
                int childIndex = GetLeftChildIndex(index);
                // if(HasRightChild(index) && GetRightChild(index) < GetLeftChild(index)) 
                if(HasRightChild(index) && Compare(GetRightChild(index), GetLeftChild(index))) 
                {
                    childIndex = GetRightChildIndex(index);
                }

                // if(_items[index] < _items[childIndex]) 
                if(Compare(_items[index], _items[childIndex])) 
                {
                    break;
                } 
                else 
                {
                    Swap(index, childIndex);
                }
                index = childIndex;
            }
        }
    }
}