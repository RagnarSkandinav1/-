using System.Collections;
using System.Collections.Generic;

namespace DoubleLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

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

        public void Add(T data)
        {
            var node = new Node<T>(data);

            if (_head == null)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;
                node.Previous = _tail;
            }

            _tail = node;
            Count++;
        }

        public void AddFirst(T data)
        {
            var node = new Node<T>(data);
            var temp = _head;
            node.Next = temp;
            _head = node;
            if (Count == 0)
                _tail = _head;
            else
                temp.Previous = node;
            Count++;
        }

        public bool Remove(T data)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Data.Equals(data)) break;
                current = current.Next;
            }

            if (current == null) return false;
            if (current.Next != null)
                current.Next.Previous = current.Previous;
            else
                _tail = current.Previous;

            if (current.Previous != null)
                current.Previous.Next = current.Next;
            else
                _head = current.Next;
            Count--;
            return true;
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

        public IEnumerable<T> BackEnumerator()
        {
            var current = _tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }
}