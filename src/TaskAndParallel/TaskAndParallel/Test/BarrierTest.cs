using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskAndParallel.Test
{
    public class BarrierTest
    {
        private Task[] tasks = new Task[4];

        private Barrier barrier = null;

        public void Demo()
        {
            barrier = new Barrier(tasks.Length, (i) =>
               {
                   Console.WriteLine("屏障中当前阶段编号:{0}\n", i.CurrentPhaseNumber);
               });
            for (int j = 0; j < tasks.Length; j++)
            {
                tasks[j] = Task.Factory.StartNew((obj) =>
                {
                    var single = Convert.ToInt32(obj);

                    LoadUser(single);
                    barrier.SignalAndWait();

                    LoadProduct(single);
                    barrier.SignalAndWait();

                    LoadOrder(single);
                    barrier.SignalAndWait();
                }, j);
            }

            Task.WaitAll(tasks);

            Console.WriteLine("指定数据库中所有数据已经加载完毕！");

            Console.Read();
        }

        static void LoadUser(int num)
        {
            Console.WriteLine("当前任务:{0}正在加载User部分数据！", num);
        }

        static void LoadProduct(int num)
        {
            Console.WriteLine("当前任务:{0}正在加载Product部分数据！", num);
        }

        static void LoadOrder(int num)
        {
            Console.WriteLine("当前任务:{0}正在加载Order部分数据！", num);
        }
    }
}
