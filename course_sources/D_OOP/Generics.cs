using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace D_OOP.Homeworks
{
    public class ArrayStack<T> : IEnumerable<T>
    {
        private T[] _items;

        public ArrayStack()
        {
            const int defaultCapacity = 4;
            _items = new T[defaultCapacity];
        }

        public ArrayStack(int capacity)
        {
            _items = new T[capacity];
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            return _items[Count - 1];
        }

        public void Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            _items[--Count] = default(T);
        }

        public void Push(T item)
        {
            if (_items.Length == Count)
            {
                T[] largerArray = new T[Count * 2];
                Array.Copy(_items, largerArray, Count);

                _items = largerArray;
            }
            _items[Count++] = item;
        }

        public bool IsEmpty => Count == 0;
        public int Count { get; private set; }
        public int Capacity => _items.Length;

//        public IEnumerator<T> GetEnumerator()
//        {
//            for (int i = Count - 1; i >= 0; i--)
//            {
//                yield return _items[i];
//            }
//        }
//
//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return GetEnumerator();
//        }

        public IEnumerator<T> GetEnumerator()
        {
            return new StackEnumerator<T>(_items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class StackEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] array;
        private int position = -1;

        public StackEnumerator(T[] array)
        {
            this.array = array;
        }
        public bool MoveNext()
        {
            position++;
            return position < array.Length;
        }

        public void Reset()
        {
            position = -1;
        }

        public T Current
        {
            get { return array[position]; }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            //no disposable resources
            //so do nothing
        }
    }

    //todo covariance p.140-142 Albahari C# 5

    public class Utility
    {
        public void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }
    }
}
