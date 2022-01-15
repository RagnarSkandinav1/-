using System;

namespace Queue
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var queue = new Queue<string>();
            queue.Enqueue("maxim");
            queue.Enqueue("sasha");
            queue.Enqueue("roma");
            queue.Enqueue("andrey");

            foreach (var item in queue)
                Console.WriteLine(item);
            Console.WriteLine();

            Console.WriteLine();
            var firstItem = queue.Dequeue();
            Console.WriteLine($"Enqueue element: {firstItem}");
            Console.WriteLine();

            foreach (var item in queue)
                Console.WriteLine(item);
        }
    }
}