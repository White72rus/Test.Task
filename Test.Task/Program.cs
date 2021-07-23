using System;

namespace Test.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var processing = new Processing();

            var worker = System.Threading.Tasks.Task.Run(()=> {
                processing.Run();
            });

            worker.Wait();

            Console.WriteLine("End");

            Console.ReadLine();
        }
    }
}
