# 基础 #

## 集合 ##



## 多线程 ##

<p>
    <image src="../img/2.jpg"></image>
</p>
**同步、异步、阻塞、非阻塞**

阻塞非阻塞：描述的是一个线程/进程的状态 它等在那里了 他就是阻塞了；

同步异步： 描述的是一个消息机制或者说一个消息系统 是关于组件之间如何传递和处理消息的

阻塞可以是异步的（a阻塞了但a和b是异步的）；非阻塞也可以是同步的（a非阻塞但a和b是同步的）。

**Lock和synchronized的选择**

1. Lock是一个接口，而synchronized是Java中的关键字，synchronized是内置的语言实现；

2. synchronized在发生异常时，会自动释放线程占有的锁，因此不会导致死锁现象发生；而Lock在发生异常时，如果没有主动通过unLock()去释放锁，则很可能造成死锁现象，因此使用Lock时需要在finally块中释放锁；

3. Lock可以让等待锁的线程响应中断，而synchronized却不行，使用synchronized时，等待的线程会一直等待下去，不能够响应中断；

4. 通过Lock可以知道有没有成功获取锁，而synchronized却无法办到。

5. Lock可以提高多个线程进行读操作的效率。

**可重入锁**

可重入的主语是已经获得该锁的线程，可重入指的就是可以再次进入，因此，意思就是已经获得该锁的线程可以再次进入被该锁锁定的代码块。内部通过计数器实现。

1. 可重入锁（递归锁）：可以再次进入方法A，就是说在释放锁前此线程可以再次进入方法A（方法A递归）。

2. 不可重入锁（自旋锁）：不可以再次进入方法A，也就是说获得锁进入方法A是此线程在释放锁钱唯一的一次进入方法A

CAS算法 即compare and swap（比较与交换），是一种有名的无锁算法。当且仅当 V 的值等于 A时，CAS通过原子方式用新值B来更新V的值，否则不会执行任何操作

**并发编程特性**

1. 原子性：即一个或者多个操作作为一个整体，要么全部执行，要么都不执行，并且操作在执行过程中不会被线程调度机制打断
2. 可见性：当多个线程访问同一个变量时，一个线程修改了这个变量的值，其他线程能够立即看得到修改的值
3. 有序性：即程序执行的顺序按照代码的先后顺序执行

**ThreadLocal**

ThreadLocal类提供了如下方法：

```java
public T get() { }
public void set(T value) { }
public void remove() { }
protected T initialValue() { }
```

- ThreadLocal的作用是数据隔离，在每一个线程中创建一个新的数据对象，每一个线程使用的是不一样的
- ThreadLocal内部的ThreadLocalMap键为弱引用，会有内存泄漏的风险。(使用完ThreadLocal之后，记得调用remove方法)
- 适用于无状态，副本变量独立后不影响业务逻辑的高并发场景。

在著名的框架Hiberante中，数据库连接的代码：

```java
private static final ThreadLocal threadSession = new ThreadLocal();  

public static Session getSession() throws InfrastructureException {  
    Session s = (Session) threadSession.get();  
    try {  
        if (s == null) {  
            s = getSessionFactory().openSession();  
            threadSession.set(s);  
        }  
    } catch (HibernateException ex) {  
        throw new InfrastructureException(ex);  
    }  
    return s;  
}  
```

**CountDownLatch、CyclicBarrier和Semaphore**

1. CountDownLatch：利用它可以实现类似计数器的功能。比如有一个任务A，它要等待其他4个任务执行完毕之后才能执行，此时就可以利用CountDownLatch来实现这种功能了。

   ```java
   //调用await()方法的线程会被挂起，它会等待直到count值为0才继续执行
   public void await() throws InterruptedException { };   
   //和await()类似，只不过等待一定的时间后count值还没变为0的话就会继续执行
   public boolean await(long timeout, TimeUnit unit) throws InterruptedException { }; 
   public void countDown() { };  //将count值减1
   ```

2. CyclicBarrier：所有等待线程都被释放以后，CyclicBarrier可以被重用

   当所有线程线程写入操作完毕之后，所有线程就继续进行后续的操作了。如果说想在所有线程写入操作完之后，进行额外的其他操作可以为CyclicBarrier提供Runnable参数

3. Semaphore：翻译成字面意思为 信号量，Semaphore可以控同时访问的线程个数，通过 acquire() 获取一个许可，如果没有就等待，而 release() 释放一个许可。

## NIO ##



 ## 反射 ##

动态代理反射



## HashMap实现原理 ##



 ## RPC ##





# Spring #



# 设计模式 #

**单例多线程**



# 项目 #





 ## MyBatis   ##





 ## Redis  ##



 ## Redis持久化 ##





 ## Shiro ##





 ## HAProxy ##





 ## Keepalived ##

ARRP：虚拟路由冗余协议

 ## RabbitMQ ##



# 其他 #

 ## Linux ##





