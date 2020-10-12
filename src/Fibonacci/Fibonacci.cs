using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Fibonacci
{
    public class Fibonacci
    {
        public static int Fib(int i)
        {
            if (i <= 2) return 1;
            return Fib(i - 2) + Fib(i - 1);
        }
        static void Main(string[] args)
        {
            IList<Task<int>> tasks = new List<Task<int>>();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var results = Compute(args);
            /*foreach (var arg in args)
            {
                var task = Task.Run(()=>Fib(int.Parse(arg)));
                tasks.Add(task);
            }*/
            //Task.WaitAll(tasks.ToArray());
            foreach (var result in results)
            {
                Console.WriteLine($"Results :{result}");
            }
            stopwatch.Stop();
            Console.WriteLine("Time :" + stopwatch.Elapsed.TotalSeconds);
        }

        public static IList<int> Compute(string[] args)
        {
            var results = new ConcurrentBag<int>();
            Parallel.ForEach(args, (args) =>
            {
                var result = Fib(int.Parse(args));
                results.Add(result);
            });
            return results.ToList();
        }

    }
}
