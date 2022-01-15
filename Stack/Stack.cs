using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class NodeStack<T> : IEnumerable<T>
    {
        private Node<T> _head;

        public bool IsEmpty => Count == 0;

        public int Count { get; private set; }

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

        public void Push(T item)
        {
            var node = new Node<T>(item)
            {
                Next = _head
            };
            _head = node;
            Count++;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            var temp = _head;
            _head = _head.Next;
            Count--;
            return temp.Data;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            return _head.Data;
        }
    }
}