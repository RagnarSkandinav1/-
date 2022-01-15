using System;

namespace Stack
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var stack = new NodeStack<string>();
            stack.Push("Timoti");
            stack.Push("anna");
            stack.Push("ivan");
            stack.Push("petrovich");

            foreach (var item in stack) Console.WriteLine(item);
            Console.WriteLine();
            var header = stack.Peek();
            Console.WriteLine($"Head of stack is: {header}");
            Console.WriteLine();

            header = stack.Pop();
            foreach (var item in stack) Console.WriteLine(item);
        }
    }
}