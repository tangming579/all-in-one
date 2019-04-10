using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskAndParallel.Test
{
    public class TaskTest
    {
        public void TaskDemo1()
        {
            var task1 = new Task(() =>
              {
                  Run1();
              });

            var task2 = Task.Factory.StartNew(() =>
              {
                  Run2();
              });

            var task3 = Task.Run(() =>
              {
                  Run3();
              });
            Console.WriteLine("调用start之前****************************\n");
            Console.WriteLine("task1的状态:{0}", task1.Status);
            Console.WriteLine("task2的状态:{0}", task2.Status);
            Console.WriteLine("task3的状态:{0}", task3.Status);

            task1.Start();
            Console.WriteLine("\n调用start之后****************************");
            Console.WriteLine("task1的状态:{0}", task1.Status);
            Console.WriteLine("task2的状态:{0}", task2.Status);
            Console.WriteLine("task3的状态:{0}", task3.Status);

            Task.WaitAll(task1, task2, task3);
            Console.WriteLine("任务执行完后的状态****************************");
            Console.WriteLine("task1的状态:{0}", task1.Status);
            Console.WriteLine("task2的状态:{0}", task2.Status);
            Console.WriteLine("task3的状态:{0}", task3.Status);
        }
        static void Run1()
        {
            Thread.Sleep(1000);
            Console.WriteLine("任务1");
        }
        static void Run2()
        {
            Thread.Sleep(1000);
            Console.WriteLine("任务2");
        }
        static void Run3()
        {
            Thread.Sleep(1000);
            Console.WriteLine("任务3");
        }

        public void TaskCancel()
        {
            var cts = new CancellationTokenSource();
            var ct = cts.Token;

            var task1 = new Task(() =>
              {
                  RunCancel1(ct);
              }, ct);

            var task2 = new Task(RunCancel2);

            try
            {
                task1.Start();
                task2.Start();

                Thread.Sleep(1000);
                cts.Cancel();
                Task.WaitAll(task1, task2);                
            }
            catch(AggregateException ex)
            {
                foreach(var e in ex.InnerExceptions)
                {
                    Console.WriteLine($"CancelException：{e.Message}");
                }
                Console.WriteLine("task1是不是被取消了？ {0}", task1.IsCanceled);
                Console.WriteLine("task2是不是被取消了？ {0}", task2.IsCanceled);
            }
        }
        static void RunCancel1(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            Console.WriteLine("Task 1");
            Thread.Sleep(2000);
            ct.ThrowIfCancellationRequested();
            Console.WriteLine("Task1第二部分");
        }
        static void RunCancel2()
        {
            Console.WriteLine("Task 2");
        }
    }
}
