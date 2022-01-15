using System;

namespace Tree
{
    public class Node<T> where T : IComparable
    {
        public Node(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public Node<T> LeftNode { get; set; }

        public Node<T> RightNode { get; set; }

        public Node<T> ParentNode { get; set; }

        public Side? NodeSide =>
            ParentNode == null
                ? null
                : ParentNode.LeftNode == this
                    ? Side.Left
                    : Side.Right;

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}