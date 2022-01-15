using System;
using SharedAttribute;

namespace TestAssembly1
{
    [Plugin("Plugin1")]
    public class TestPlugin1
    {
        public void Print()
        {
            Console.WriteLine(nameof(TestPlugin1) + " " + nameof(Print));
        }

        public void Message()
        {
            Console.WriteLine("Message");
        }
    }
}