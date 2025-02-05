using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using essentials2;

namespace essentials2
{
    public static class DelegateSamples
    {
        // event handling
        public static event Action<string>? SomethingHappened;

        // delegate methods do not have implementations
        //public delegate void Del(string userInput);

        // pass in an Action (delegate) as a parameter, the Action takes a string as an argument
        // Action<> does something, NO return (use when passing a method that does not return anything)
        public static void PassWork(Action<string> work, string inp)
        {
            work(inp); // we can use the parameter as a function, good for function reuse
        }

        // string argument, int return type
        // Func<> does something, returns something (use when passing a method that returns something)
        public static void PassLogic(Func<string, int> worker)
        {
            // invoke the function passed in as a parameter
            int count = worker("worker me"); 
            Console.WriteLine($"Return {count}");

        }

        public static void doWork(string input)
        {
            Console.WriteLine($"Work done: {input}");
            if (SomethingHappened != null)
            {
                // invokes SomethingHappened event, which then invokves all the methods of type Del
                SomethingHappened("work done");
            }

        }

    }
}
