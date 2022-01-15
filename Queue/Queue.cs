using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
    public class Queue<T> : IEnumerable<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return _head.Data;
            }
        }

        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return _tail.Data;
            }
        }

        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public void Enqueue(T data)
        {
            var node = new Node<T>(data);
            var tempNode = _tail;
            _tail = node;
            if (Count == 0)
                _head = _tail;
            else
                tempNode.Next = _tail;
            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            var output = _head.Data;
            _head = _head.Next;
            Count--;
            return output;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public bool Contains(T data)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }

            return false;
        }
    }
}