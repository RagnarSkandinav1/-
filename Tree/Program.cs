using System;

namespace Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var binaryTree = new BinaryTree<int>();

            binaryTree.Add(9);
            binaryTree.Add(1);
            binaryTree.Add(11);
            binaryTree.Add(2);
            binaryTree.Add(4);
            binaryTree.Add(6);
            binaryTree.Add(8);
            binaryTree.Add(13);
            binaryTree.Add(14);

            binaryTree.PrintTree();

            Console.WriteLine(new string('-', 40));
            binaryTree.Remove(3);
            binaryTree.PrintTree();

            Console.WriteLine(new string('-', 40));
            binaryTree.Remove(8);
            binaryTree.PrintTree();

            Console.ReadLine();
        }
    }
}