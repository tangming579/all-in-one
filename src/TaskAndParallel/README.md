# C#并发编程总结

> 一旦你输入new Thread() ，那就糟糕了，说明项目中的代码太过时了—《C#并发编程经典实例》

### Paraller的使用

**Parallel的使用**

在Parallel下面有三个常用的方法invoke,for和forEach。

1. Parallel.Invoke

   ```c#
   public class ParallelTest
       {
           public void ParallelInvoke()
           {
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
               Console.WriteLine("Task 1 耗时3s");
               Thread.Sleep(3000);
           }
           public void Run2()
           {
               Console.WriteLine("Task 2 耗时2s");
               Thread.Sleep(2000);
           }
       }
   ```

2. Parallel.for

   ```c#
    public class ParallelTest
       {
           //因为拆分任务的开销与任务本身的难度比还要高,所以拆分并行就不如串行了.
           public void ParallelFor()
           {
               var items1 = new List<int>(3000000);
               for(int i = 0; i < 4; i++)
               {
                   Console.WriteLine($"第{i}次比较");
                   var watch = Stopwatch.StartNew();
                   watch.Start();
                   for(int j = 0; j < 3000000; j++)
                   {
                       items1.Add(j);
                   }
                   Console.WriteLine($"串行计算，集合共耗时：watch.ElapsedMilliseconds}");
                   GC.Collect();
                   var items2 = new List<int>(3000000);
                   watch = Stopwatch.StartNew();
                   watch.Start();
                   Parallel.For(0, 3000000, j =>
                   {
                       items2.Add(j);
                   });
                   Console.WriteLine($"并行计算，集合共耗时：watch.ElapsedMilliseconds}");
               }
           }
       }
   ```

3. Parallel.forEach

   ```c#
   
   ```


### Task的使用



### PLinq的使用



### 同步机制（上）



### 同步机制（下）



### 异步编程模型



### 任务与线程池



### 用VS性能剖析程序



