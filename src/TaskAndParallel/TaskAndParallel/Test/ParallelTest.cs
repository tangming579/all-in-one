using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskAndParallel.Test
{
    public class ParallelTest
    {
        public void ParallelInvoke()
        {
            Console.WriteLine($"主线程ID：{Thread.CurrentThread.ManagedThreadId}");
            var watch = Stopwatch.StartNew();
            watch.Start();

            Run1();
            Run2();

            Console.WriteLine($"串行情况下总耗时：{watch.ElapsedMilliseconds}");

            watch.Restart();
            Parallel.Invoke(Run1, Run2);

            Console.WriteLine($"并行情况下总耗时：{watch.ElapsedMilliseconds}");
            watch.Stop();

            Console.ReadKey();
        }

        public void Run1()
        {
            Console.WriteLine($"Task 1 耗时3s，线程ID：{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(3000);
        }

        public void Run2()
        {
            Console.WriteLine($"Task 2 耗时2s，线程ID：{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);
        }

        //因为拆分任务的开销与任务本身的难度比还要高,所以拆分并行就不如串行了.
        public void ParallelFor()
        {
            var items1 = new List<int>(3000000);

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"第{i}次比较");

                var watch = Stopwatch.StartNew();
                watch.Start();

                for (int j = 0; j < 3000000; j++)
                {
                    items1.Add(j);
                }

                Console.WriteLine($"串行计算，集合共耗时：{watch.ElapsedMilliseconds}");

                GC.Collect();

                var items2 = new List<int>(3000000);
                watch = Stopwatch.StartNew();
                watch.Start();
                Parallel.For(0, 3000000, j =>
                {
                    items2.Add(j);
                });

                Console.WriteLine($"并行计算，集合共耗时：{watch.ElapsedMilliseconds}");
                GC.Collect();
            }
        }
        //同样，因为拆分任务的开销与任务本身的难度比还要高,所以拆分并行就不如串行了.
        public void ParallelForeach()
        {
            var items1 = new List<int>(3000000);
            for (int i = 1; i < 4; i++)
            {
                Console.WriteLine($"第{i}次比较");

                var watch = Stopwatch.StartNew();
                watch.Start();

                for (int j = 0; j < 3000000; j++)
                {
                    items1.Add(j);
                }

                Console.WriteLine($"串行计算，集合共耗时：{watch.ElapsedMilliseconds}");

                GC.Collect();

                var items2 = new List<int>(3000000);
                items2.Clear();
                watch = Stopwatch.StartNew();
                watch.Start();
                Parallel.ForEach(Partitioner.Create(0, 3000000), j =>
                {                    
                    for (int m = j.Item1; m < j.Item2; m++)
                    {
                        items2.Add(m);
                    }
                });

                Console.WriteLine($"并行计算，集合共耗时：{watch.ElapsedMilliseconds}");
                GC.Collect();
            }
        }
    }
}
