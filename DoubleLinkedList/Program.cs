using System;

namespace DoubleLinkedList
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var linkedList = new DoublyLinkedList<string>
            {
                "Varvara",
                "Sasha",
                "Ira"
            };
            linkedList.AddFirst("Varvara");
            foreach (var item in linkedList) Console.WriteLine(item);
            Console.WriteLine();
            linkedList.Remove("Sasha");

            foreach (var t in linkedList.BackEnumerator()) Console.WriteLine(t);
        }
    }
}