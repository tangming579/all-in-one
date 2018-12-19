# 基础

## 集合

<p>
    <image src="/documents/img/3.gif"></image>
</p>

- List集合是有序集合，集合中的元素可以重复，访问集合中的元素可以根据元素的索引来访问，查找元素效率高，插入删除效率低。
- Set集合是无序集合，集合中的元素不可以重复，检索效率低下，删除和插入效率高，访问集合中的元素只能根据元素本身来访问
- Map集合中保存Key-value对形式的元素，访问时只能根据每项元素的key来访问其value。

**ArrayList与Vector的区别**

1. 两者都是基于索引，内部结构是数组

2. 元素存取有序并都允许为null

3. 都支持fail-fast机制

4. Vector是同步的，不会过载，而ArrayList不是，但ArrayList效率比Vector高，如果在迭代中对集合做修改可以使用CopyOnWriteArrayList

5. 初始容量都为10，但ArrayList默认增长为原来的50%，而Vector默认增长为原来的一倍，并且可以设置
   ArrayList更通用，可以使用Collections工具类获取同步列表和只读列表

   适用场景分析： 
   1、Vector是线程同步的，所以它也是线程安全的，而ArrayList是线程异步的，是不安全的。如果不考虑到线程的安全因素，一般用ArrayList效率比较高。 
   2、如果集合中的元素的数目大于目前集合数组的长度时，在集合中使用数据量比较大的数据，用Vector有一定的优势。

**ArrayList与LinkedList的区别**

1. ArrayList基于数组，LinkedList基于链表
2. ArrayList查找快，LinkedList插入删除快
3. 随机查找频繁用ArrayList,插入删除频繁用LinkedList

**ArrayList,Vector,HashMap,Hashtable扩容机制？**

1. arraylist,初始容量10，(oldCapacity * 3)/2 + 1
2. vector,初始容量10，oldCapacity * 2
3. hashmap,初始容量16，达到阀值扩容，为原来的两倍
4. hashtable，初始容量11，达到阀值扩容，oldCapacity * 2 + 1

**HashMap实现原理**

- hashmap是数组和链表的结合体，数组每个元素存的是链表的头结点
- 往hashmap里面放键值对的时候先得到key的hashcode，然后重新计算hashcode，（让1分布均匀因为如果分布不均匀，低位全是0，则后来计算数组下标的时候会冲突），然后与length-1按位与，计算数组出数组下标
- 如果该下标对应的链表为空，则直接把键值对作为链表头结点，如果不为空，则遍历链表看是否有key值相同的，有就把value替换，没有就把该对象最为链表的第一个节点，原有的节点最为他的后续节点
- 初始容量16，达到阀值扩容，阀值等于最大容量*负载因子，扩容每次2倍，总是2的n次方

**HashMap HashTable区别？，Hashmap key可以是任何类型吗？**

- 区别：
  1. HashTable的方法是同步的，HashMap方法未经同步，所以在多线程场合要手动同步HashMap这个区别和Vector和ArrayList一样
  2. Hashtable不允许null值（key和value都不可以），HashMap允许null值（key和value都可以）
  3. 哈希值的使用不同，Hashtable直接使用对象的HashCode。二HashMap重新计算Hash值，而且用于代替求模。
  4. HashTable中Hash数字默认大小是11，增加的方式是old*2+1。HashMap中Hash数组的默认大小是16，而且一定是2的指数。
- 需要同时重写该类的hashCode()方法和它的equals()方法。

**并发集合—ConcurrentHashMap**

ConcurrentHashMap是线程安全的，用来替代HashTable。

ConcurrentHashMap使用分段锁技术，将数据分成一段一段的存储，然后给每一段数据配一把锁，当一个线程占用锁访问其中一个段数据的时候，其他段的数据也能被其他线程访问，能够实现真正的并发访问。

**并发集合—CopyOnWriteArrayList和CopyOnWriteArraySet**

CopyOnWrite容器即写时复制的容器。通俗的理解是当我们往一个容器添加元素的时候，不直接往当前容器添加，而是先将当前容器进行Copy，复制出一个新的容器，然后新的容器里添加元素，添加完元素之后，再将原容器的引用指向新的容器。这样做的好处是我们可以对CopyOnWrite容器进行并发的读，而不需要加锁，因为当前容器不会添加任何元素。所以CopyOnWrite容器也是一种读写分离的思想，读和写不同的容器。

## 多线程

<p>
    <image src="/documents/img/2.jpg"></image>
</p>

**同步、异步、阻塞、非阻塞**

阻塞非阻塞：描述的是一个线程/进程的状态 它等在那里了 他就是阻塞了；

同步异步： 描述的是一个消息机制或者说一个消息系统 是关于组件之间如何传递和处理消息的

阻塞可以是异步的（a阻塞了但a和b是异步的）；非阻塞也可以是同步的（a非阻塞但a和b是同步的）。

**实现多线程方式**

- 实现多线程方式
  - 继承Thread类，重写run函数
  - 实现Runnable接口
  - 实现Callable接口
- 三种方式区别
  - 实现Runnable接口可以避免java单继承特性带来的局限；增强程序的健壮性，代码能够被多个线程共享，代码与数据是独立的；适合多个相同程序代码的线程区处理同一资源的情况
  - 继承Thread和实现Runnable接口启动线程都是使用start方法，然后JVM虚拟机将此线程放倒就绪队列中，如果有处理机可用，则执行run方法
  - 实现Callable接口要实现call方法，并且线程执行完毕后会有返回值，其他两种都是重新run，没有返回值

**Lock和synchronized的选择**

1. Lock是一个接口，而synchronized是Java中的关键字，synchronized是内置的语言实现；
2. synchronized在发生异常时，会自动释放线程占有的锁，因此不会导致死锁现象发生；而Lock在发生异常时，如果没有主动通过unLock()去释放锁，则很可能造成死锁现象，因此使用Lock时需要在finally块中释放锁；
3. Lock可以让等待锁的线程响应中断，而synchronized却不行，使用synchronized时，等待的线程会一直等待下去，不能够响应中断；
4. 通过Lock可以知道有没有成功获取锁，而synchronized却无法办到。
5. Lock可以提高多个线程进行读操作的效率。

**Volatile**

解释：被volatile修饰的变量对所有线程可见，它是放在共享内存中的

- 具有可见性：确保释放锁之前对共享数据做出的更改对于随后获得该锁的另一个线程是可见的
- 没有原子性：只有一个线程能够执行一段代码，这段代码通过一个monitor object保护。从而防止多个线程在更新共享状态时相互冲突

使用场景：

1. 希望用轻量级的同步提高性能
2. 对变量的写操作不依赖于当前值
3. 该变量没有包含在具有其他变量的不变式中

**wait,notify,notifyAll**

- wait:导致当前线程等待，这个方法会释放锁，所以需要在同步代码块中调用(否则会发生
  IllegalMonitorStateException的异常
- notify:随机选择一个等待中的线程将其唤醒；notify()调用后，并不是马上就释放对象锁
  的，而是在相应的synchronized(){}语句块执行结束，自动释放锁后，JVM会在wait()对象
  锁的线程中随机选取一线程，赋予其对象锁，唤醒线程，继续执行。
- notifyAll:将所有等待的线程唤醒

**join,sleep,yield**

- join:等待调用该方法的线程执行完毕后再往下继续执行(该方法也要捕获异常)
- sleep:使调用该方法的线程暂停执行一段时间，让其他线程有机会继续执行，但它并不释
  放对象锁。也就是如果有Synchronized同步块，其他线程仍然不同访问共享数据(注意该
  方法要捕获异常)
- yeild:与sleep()类似，只是不能由用户指定暂停多长时间，并且yield()方法只能让同优先
  级的线程有执行的机会

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

**线程池**

构造函数：

```java
public ThreadPoolExecutor(int corePoolSize,int maximumPoolSize,long keepAliveTime,TimeUnit unit,BlockingQueue<Runnable> workQueue);
```

- corePoolSize：核心池的大小
- maximumPoolSize：线程池最大线程数，它表示在线程池中最多能创建多少个线程
- keepAliveTime：表示线程没有任务执行时最多保持多久时间会终止。
- unit：参数keepAliveTime的时间单位
- workQueue：一个阻塞队列，用来存储等待执行的任务

在ThreadPoolExecutor类中有几个非常重要的方法：

```
`execute()``submit()``shutdown()``shutdownNow()`
```

线程池的关闭　　

- shutdown()：不会立即终止线程池，而是要等所有任务缓存队列中的任务都执行完后才终止，但再也不会接受新的任务
- shutdownNow()：立即终止线程池，并尝试打断正在执行的任务，并且清空任务缓存队列，返回尚未执行的任务

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

**Syschronized关键字 Sychronized代码块区别？static synchroniezd?**

- synchronized代码块比synchronized方法要灵活。因为也许一个方法中只有一部分代码只需要同步，如果此时对整个方法用synchronized进行同步，会影响程序执行效率。而使用synchronized代码块就可以避免这个问题，synchronized代码块可以实现只对需要同步的地方进行同步。
- 如果一个线程执行一个对象的非static synchronized方法，另外一个线程需要执行这个对象所属类的static synchronized方法，此时不会发生互斥现象，因为访问static synchronized方法占用的是类锁，而访问非static synchronized方法占用的是对象锁，所以不存在互斥现象

**Callable、Future、FutureTask**



## NIO

参考：http://wiki.jikexueyuan.com/project/java-nio-zh/java-nio-tutorial.html

Java NIO基本组件如下：

<p>
	<image src="/documents/img/nio1.png"></image>
</p>

- 通道和缓冲区(*Channels and Buffers*)：在标准I/O API中，使用字符流和字节流。 在NIO中，使用通道和缓冲区。数据总是从缓冲区写入通道，并从通道读取到缓冲区。
- 选择器(*Selectors*)：Java NIO提供了“选择器”的概念。这是一个可以用于监视多个通道的对象，如数据到达，连接打开等。因此，单线程可以监视多个通道中的数据。
- 非阻塞I/O(*Non-blocking I/O*)：Java NIO提供非阻塞I/O的功能。这里应用程序立即返回任何可用的数据，应用程序应该具有池化机制，以查明是否有更多数据准备就绪。

## 反射

动态代理



## RPC



# jvm



# 数据库 #

**数据库优化**



**索引查找、索引扫描**



**ACID**



**四种数据库隔离级别**

1. Serializable （串行化）：最严格的级别，事务串行执行，资源消耗最大；
2. REPEATABLE READ（重复读） ：保证了一个事务不会修改已经由另一个事务读取但未提交（回滚）的数据。避免了“脏读取”和“不可重复读取”的情况，但不能避免“幻读”，但是带来了更多的性能损失。
3. READ COMMITTED （提交读）：大多数主流数据库的默认事务等级，保证了一个事务不会读到另一个并行事务已修改但未提交的数据，避免了“脏读取”，但不能避免“幻读”和“不可重复读取”。该级别适用于大多数系统。
4. Read Uncommitted（未提交读） ：事务中的修改，即使没有提交，其他事务也可以看得到，会导致“脏读”、“幻读”和“不可重复读取

**事务隔离级别**

脏读：读取了另一个事务提交的数据

幻读：读取一次，在读第二次之前insert或者是delete，导致读取的记录数不同

不可重复读：读取一次，在第二次读之前更新了这个数据导致两次数据不同。

## B树、B+树



## Redis

Redis持久化：

- Redis DataBase(简称RDB)
  - 执行机制：快照，直接将databases中的key-value的二进制形式存储在了rdb文件中
  - 优点：性能较高（因为是快照，且执行频率比aof低，而且rdb文件中直接存储的是key-values的二进制形式，对于恢复数据也快）
  - 使用单独子进程来进行持久化，主进程不会进行任何IO操作，保证了redis的高性能
  - 缺点：在save配置条件之间若发生宕机，此间的数据会丢失
  - RDB是间隔一段时间进行持久化，如果持久化之间redis发生故障，会发生数据丢失。所以这种方式更适合数据要求不严谨的时候
- Append-only file (简称AOF)
  - 执行机制：将对数据的每一条修改命令追加到aof文件
  - 优点：数据不容易丢失
  - 可以保持更高的数据完整性，如果设置追加file的时间是1s，如果redis发生故障，最多会丢失1s的数据；且如果日志写入不完整支持redis-check-aof来进行日志修复；AOF文件没被rewrite之前（文件过大时会对命令进行合并重写），可以删除其中的某些命令（比如误操作的flushall
  - 缺点：性能较低（每一条修改操作都要追加到aof文件，执行频率较RDB要高，而且aof文件中存储的是命令，对于恢复数据来讲需要逐行执行命令，所以恢复慢）
  - AOF文件比RDB文件大，且恢复速度慢。



# Spring



# 设计模式

## 单例多线程





# 项目



 **MyBatis**

 

 **Shiro**





**HAProxy**





**Keepalived**

ARRP：虚拟路由冗余协议

 **RabbitMQ**



# 其他

 **Linux**





