using System;

namespace Heaps
{
    public class MinHeap
    {
        private int _capacity;
        private int _size;
        private int[] _items;

        public MinHeap()
            : this(10)
        {}

        public MinHeap(int capacity) 
        {
            _capacity = capacity;
            _size = 0;

            _items = new int[_capacity];
        }

        public int Peek() 
        {
            if(IsEmpty) 
            {
                throw new InvalidOperationException();
            }

            return _items[0];
        }

        public int Poll() 
        {
            if(IsEmpty) 
            {
                throw new InvalidOperationException();
            }
            
            int item = _items[0];
            _items[0] = _items[_size - 1];
            _size--;
            HeapifyDown();
            
            return item;
        }

        public void Add(int item)
        {
            EnsureCapacity();

            _items[_size] = item;
            _size++;
            HeapifyUp();
        }

        private int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
        private int GetRightChildIndex(int parentIndex) => 2 * (parentIndex + 1);
        private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;

        private bool IsEmpty => _size == 0;
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
                int[] temp = new int[_capacity];
                _items.CopyTo(temp, 0);
                _items = temp;
            }
        
        }

        private void HeapifyUp()
        {
            int index = _size - 1;
            while(HasParent(index) && GetParent(index) > _items[index]) {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }

        private void HeapifyDown()
        {
            int index = 0;
            while(HasLeftChild(index)) 
            {
                int smallerChildIndex = GetLeftChildIndex(index);
                if(HasRightChild(index) && GetRightChild(index) < GetLeftChild(index)) 
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }
            }
        }
    }
}