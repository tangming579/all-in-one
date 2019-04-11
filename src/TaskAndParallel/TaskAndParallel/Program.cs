using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAndParallel.Test;

namespace TaskAndParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            //ParallelTest test = new ParallelTest();
            //test.ParallelForeach();

            //TaskTest test = new TaskTest();
            //test.TaskDemo1();

            PLinqTest test = new PLinqTest();
            test.Demo1();

            Console.ReadKey();
        }
    }
}
