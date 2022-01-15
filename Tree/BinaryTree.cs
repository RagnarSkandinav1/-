using System;

namespace Tree
{
    public class BinaryTree<T> where T : IComparable
    {
        public Node<T> RootNode { get; set; }

        private Node<T> Add(Node<T> node, Node<T> currentNode = null)
        {
            while (true)
            {
                if (RootNode == null)
                {
                    node.ParentNode = null;
                    return RootNode = node;
                }

                currentNode ??= RootNode;
                node.ParentNode = currentNode;
                int result;
                if ((result = node.Data.CompareTo(currentNode.Data)) == 0) return currentNode;
                if (result < 0)
                {
                    if (currentNode.LeftNode == null) return currentNode.LeftNode = node;
                    currentNode = currentNode.LeftNode;
                    continue;
                }

                if (currentNode.RightNode == null) return currentNode.RightNode = node;
                currentNode = currentNode.RightNode;
            }
        }

        public Node<T> Add(T data)
        {
            return Add(new Node<T>(data));
        }

        public Node<T> FindNode(T data, Node<T> startWithNode = null)
        {
            while (true)
            {
                startWithNode ??= RootNode;
                int result;
                if ((result = data.CompareTo(startWithNode.Data)) == 0) return startWithNode;
                if (result < 0)
                {
                    if (startWithNode.LeftNode == null) return null;
                    startWithNode = startWithNode.LeftNode;
                    continue;
                }

                if (startWithNode.RightNode == null) return null;
                startWithNode = startWithNode.RightNode;
            }
        }

        private void Remove(Node<T> node)
        {
            if (node == null) return;

            var currentNodeSide = node.NodeSide;
            switch (node.LeftNode)
            {
                case null when node.RightNode == null:
                {
                    if (currentNodeSide == Side.Left)
                        node.ParentNode.LeftNode = null;
                    else
                        node.ParentNode.RightNode = null;

                    break;
                }
                case null:
                {
                    if (currentNodeSide == Side.Left)
                        node.ParentNode.LeftNode = node.RightNode;
                    else
                        node.ParentNode.RightNode = node.RightNode;

                    node.RightNode.ParentNode = node.ParentNode;
                    break;
                }
                default:
                {
                    if (node.RightNode == null)
                    {
                        if (currentNodeSide == Side.Left)
                            node.ParentNode.LeftNode = node.LeftNode;
                        else
                            node.ParentNode.RightNode = node.LeftNode;

                        node.LeftNode.ParentNode = node.ParentNode;
                    }
                    else
                    {
                        switch (currentNodeSide)
                        {
                            case Side.Left:
                                node.ParentNode.LeftNode = node.RightNode;
                                node.RightNode.ParentNode = node.ParentNode;
                                Add(node.LeftNode, node.RightNode);
                                break;
                            case Side.Right:
                                node.ParentNode.RightNode = node.RightNode;
                                node.RightNode.ParentNode = node.ParentNode;
                                Add(node.LeftNode, node.RightNode);
                                break;
                            default:
                                var bufLeft = node.LeftNode;
                                var bufRightLeft = node.RightNode.LeftNode;
                                var bufRightRight = node.RightNode.RightNode;
                                node.Data = node.RightNode.Data;
                                node.RightNode = bufRightRight;
                                node.LeftNode = bufRightLeft;
                                Add(bufLeft, node);
                                break;
                        }
                    }

                    break;
                }
            }
        }

        public void Remove(T data)
        {
            var foundNode = FindNode(data);
            Remove(foundNode);
        }

        public void PrintTree()
        {
            PrintTree(RootNode);
        }

        private static void PrintTree(Node<T> startNode, string indent = "", Side? side = null)
        {
            if (startNode == null) return;
            var nodeSide = side switch
            {
                null => "+",
                Side.Left => "L",
                _ => "R"
            };
            Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Data}");
            indent += new string(' ', 3);
            PrintTree(startNode.LeftNode, indent, Side.Left);
            PrintTree(startNode.RightNode, indent, Side.Right);
        }
    }
}