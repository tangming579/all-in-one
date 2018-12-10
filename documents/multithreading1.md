# MultiThreading-01

**1.线程的周期及五种形态**

<p align="center">
 <img height="400" src="./img/1.jpg?sanitize=true">
</p>

**新建状态（New）：**当线程对象对创建后，即进入了新建状态，如：Thread t = new MyThread();

**就绪状态（Runnable）：**当调用线程对象的start()方法（t.start();），线程即进入就绪状态。处于就绪状态的线程，只是说明此线程已经做好了准备，随时等待CPU调度执行，并不是说执行了t.start()此线程立即就会执行；

**运行状态（Running）：**当CPU开始调度处于就绪状态的线程时，此时线程才得以真正执行，即进入到运行状态。注：就     绪状态是进入到运行状态的唯一入口，也就是说，线程要想进入运行状态执行，首先必须处于就绪状态中；

**阻塞状态（Blocked）：**处于运行状态中的线程由于某种原因，暂时放弃对CPU的使用权，停止执行，此时进入阻塞状态，直到其进入到就绪状态，才 有机会再次被CPU调用以进入到运行状态。根据阻塞产生的原因不同，阻塞状态又可以分为三种：

1. 等待阻塞：运行状态中的线程执行wait()方法，使本线程进入到等待阻塞状态；

2. 同步阻塞 -- 线程在获取synchronized同步锁失败(因为锁被其它线程所占用)，它会进入同步阻塞状态；

3. 其他阻塞 -- 通过调用线程的sleep()或join()或发出了I/O请求时，线程会进入到阻塞状态。当sleep()状态超时、join()等待线程终止或者超时、或者I/O处理完毕时，线程重新转入就绪状态。

**死亡状态（Dead）：**线程执行完了或者因异常退出了run()方法，该线程结束生命周期。



**2.Runable与Thread创建线程**

```
public class ThreadTest {

    public static void main(String[] args) {
        for (int i = 0; i < 100; i++) {
            System.out.println(Thread.currentThread().getName() + " " + i);
            if (i == 30) {
                Runnable myRunnable = new MyRunnable();
                Thread thread = new MyThread(myRunnable);
                thread.start();
            }
        }
    }
}

class MyRunnable implements Runnable {
    private int i = 0;

    @Override
    public void run() {
        System.out.println("in MyRunnable run");
        for (i = 0; i < 100; i++) {
            System.out.println(Thread.currentThread().getName() + " " + i);
        }
    }
}

class MyThread extends Thread {

    private int i = 0;
    
    public MyThread(Runnable runnable){
        super(runnable);
    }

    @Override
    public void run() {
        System.out.println("in MyThread run");
        for (i = 0; i < 100; i++) {
            System.out.println(Thread.currentThread().getName() + " " + i);
        }
    }
}
```

**3.Callable和FutureTask创建线程**

```
public class MyCallable implements Callable<Integer> {
    int i = 0;

    @Override
    public Integer call() {
        int sum = 0;
        for (; i < 10; i++) {
            System.out.println(Thread.currentThread().getName() + i);
            sum += i;
        }
        return sum;
    }
}

public static void main(String[] args) {
        SpringApplication.run(DemoApplication.class, args);
        Callable<Integer> callable = new MyCallable();
        FutureTask<Integer> task = new FutureTask<Integer>(callable);
        for (int i = 0; i < 100; i++) {
            System.out.println(Thread.currentThread().getName() + " " + i);
            if (i == 30) {
                Thread thread = new Thread(task);
                thread.start();
            }
        }
        try {
            int sum = task.get();
            System.out.println("Sum is " + sum);
        } catch (InterruptedException e) {

        } catch (ExecutionException e) {

        }
    }
```

