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
            ParallelTest test = new ParallelTest();
            test.ParallelFor();

            Console.ReadKey();
        }
    }
}
