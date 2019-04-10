# C#并发编程总结

> 一旦你输入new Thread() ，那就糟糕了，说明项目中的代码太过时了—《C#并发编程经典实例》

### Parallel的使用

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
                   Console.WriteLine($"串行计算，集合共耗时：watch.ElapsedMilliseconds}");
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
                   Console.WriteLine($"并行计算，集合共耗时：watch.ElapsedMilliseconds}");
                   GC.Collect();
               }
   ```

**注意**

1. 如何退出循环

   在串行代码中break一下就可以了，但是并行就不是这么简单了，不过没关系，在并行循环的委托参数中提供了一个ParallelLoopState，该实例提供了Break和Stop方法来帮我们实现。

   - Break： 当然这个是通知并行计算尽快的退出循环，比如并行计算正在迭代100，那么break后程序还会迭代所有小于100的。

   - Stop：这个就不一样了，比如正在迭代100突然遇到stop，那它啥也不管了，直接退出。

2. 如何捕获异常

   任务是并行计算的，处理过程中可能会产生n多的异常。Exception只能捕获到最后一个异常，而使用AggregateExcepation就可以获取到一组异常

   ```c#
   static void Main(string[] args)
       {
           try
           {
               Parallel.Invoke(Run1, Run2);
           }
           catch (AggregateException ex)
           {
               foreach (var single in ex.InnerExceptions)
               {
                   Console.WriteLine(single.Message);
               }
           }
       }
   ```

### Task的使用

Task的背后的实现也是使用了线程池线程，但它的性能优于ThreadPool，因为它使用的不是线程池的全局队列，而是使用的本地队列，使线程之间的资源竞争减少。同时Task提供了丰富的API来管理线程、控制。任务跟线程不是一对一的关系，比如开10个任务并不是说会开10个线程，这一点任务有点类似线程池，但是任务相比线程池有很小的开销和精确的控制。

**Task的生命周期**

- Created：表示默认初始化任务，但是“工厂创建的”实例（Task.Factory.StartNew、Task.Run）直接跳过。

- WaitingToRun: 这种状态表示等待任务调度器分配线程给任务执行。

- RanToCompletion：任务执行完毕。

**取消Task任务**

“取消标记”：CancellationTokenSource.Token，在创建task的时候传入此参数，就可以将主线程和任务相关联，然后在任务中设置“取消信号“叫做ThrowIfCancellationRequested来等待主线程使用Cancel来通知，一旦cancel被调用。task将会抛出OperationCanceledException来中断此任务的执行，最后将当前task的Status的IsCanceled属性设为true。 

**ContinueWith**

```c#
static void Main(string[] args)
    {
        //执行task1
        var t1 = Task.Factory.StartNew<List<string>>(() => { return Run1(); });
        var t2 = t1.ContinueWith((i) =>
        {
            Console.WriteLine("t1集合中返回的个数：" + string.Join(",", i.Result));
        });
        Console.Read();
    }
```



### PLinq的使用



### 同步机制（上）



### 同步机制（下）



### 异步编程模型



### 任务与线程池



### 用VS性能剖析程序



