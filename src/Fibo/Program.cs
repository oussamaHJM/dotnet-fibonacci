using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Fibo
{
    class Program
    {
        public static int Fib(int i)
        {
            if (i <= 2) return 1;
            return Fib(i-2)+Fib(i-1);
        }
        static void Main(string[] args)
        {
            IList<Task<int>> tasks = new List<Task<int>>();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var results = Fibonacci.Fibonacci.Compute(args);
            
            //Task.WaitAll(tasks.ToArray());
            foreach(var result in results)
            {
                Console.WriteLine($"Results :{result}");
            }
            stopwatch.Stop();
            Console.WriteLine("Time :" + stopwatch.Elapsed.TotalSeconds);
        }
    }
}
