using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace essentials2
{
    public static class ThreadSamples
    {
        public static void SimpleThread()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Main thread id: {Thread.CurrentThread.ManagedThreadId}");
            Console.ResetColor();

            Thread t = new Thread(DoFileWork);
            
            t.Start();
            t.Join();
            Console.WriteLine("Work happening in main thread.");
            
            Console.WriteLine("After all done");
        }

        public static void DoFileWork()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"File access thread id: {Thread.CurrentThread.ManagedThreadId}");
            Console.ResetColor();

            string filePath = "C:\\Users\\vikramr\\source\\repos\\csharp\\essentials2\\rahul.json";
            //this could take a while
            var employeeJson = File.ReadAllText(filePath);

            var matt = JsonSerializer.Deserialize<Company>(employeeJson);

            Console.WriteLine($"Employee read from file: {matt}");
        }

        // old async method
        //File.BeginReadAllText(filePath, EndReadingFile, state);

        //public void EndReadingFile(object state, IAsyncResult iar){
        //handle the completion of file reading
        //}

        // async keyword, return type Task
        public static async Task SimpleThreadAsync()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Main thread id: {Thread.CurrentThread.ManagedThreadId}");
            Console.ResetColor();

            try
            {
                // construct Tasks for asynchronous calling, useful for multiple async await calls
                Task tRahul =  DoFileWorkAsync("rahul");
                Task tTesla = DoFileWorkAsync("teslaWrong");

                Console.WriteLine("Work happening in main thread.");
                // await keyword: This allows the calling thread to perform other work while waiting for the Task to complete.
                Task.WaitAll(tRahul, tTesla); // concurrent running of tasks

            }
            catch (AggregateException e) // task async model uses AgEx, a collection of multiple exceptions
            {
                e.Handle((innerHandle) => innerHandle is JsonException); // handle json exception
                Console.WriteLine($"Error: {e.Message}");

            }
        }

        public static async Task DoFileWorkAsync(string empName)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"File access thread id: {Thread.CurrentThread.ManagedThreadId}");
            Console.ResetColor();

            string filePath = $"C:\\Users\\vikramr\\source\\repos\\csharp\\essentials2\\{empName}.json";
            var employeeJson = await File.ReadAllTextAsync(filePath);

            var matt = JsonSerializer.Deserialize<Company>(employeeJson);

            Console.WriteLine($"Employee read from file: {matt}");
        }
    }
}
