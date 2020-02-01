### EventWaitHandler

在.NET的System.Threading命名空间中有一个名叫WaitHandler的类，这是一个抽象类(abstract),我们无法手动去创建它，但是WaitHandler有三个子类，这三个子类分别是：

```
System.Threading.EventWaitHandle

System.Threading.Mutex

System.Threading.Semaphore
```

EventWaitHandle类的用途是可以调用其WaitOne方法来阻塞线程的运行，直到得到一个信号（该信号由EventWaitHandle类的Set方法发出），然后释放线程让其不再阻塞继续运行。

构造函数

```
//initialState: true终止状态，false非终止状态
//EventResetMode：AutoReset自动，AutoReset手动
EventWaitHandle(bool initialState, EventResetMode mode);
```

EventWaitHandle类拥有两种状态，**终止状态** 和 **非终止状态**：

- 在终止状态下，被WaitOne阻塞的线程会逐个得到释放，所以当EventWaitHandle始终处于终止状态时，调用其WaitOne方法无法起到阻塞线程的作用，因为线程被其WaitOne方法阻塞后，会立即被释放掉。
- 在非终止状态下，被WaitOne阻塞的线程会继续被阻塞，如果一个线程在EventWaitHandle对象处于非终止状态时调用了其WaitOne函数，该线程会立即被阻塞。

需要注意的是终止状态和非终止状态之间，是可以相互转换的。调用EventWaitHandle对象的Set方法既可以将EventWaitHandle对象设置为终止状态，调用EventWaitHandle对象的Reset方法既可以将EventWaitHandle对象设置为非终止状态。

此外，EventWaitHandle类还拥有两种模式，**AutoReset** 和 **ManualReset** 模式：

- 在AutoReset模式下，当EventWaitHandle对象被置为终止状态时，释放一个被WaitOne阻塞的线程后，EventWaitHandle对象会马上被设置为非终止状态，这个过程就等同于一个被WaitOne阻塞的线程被释放后，自动调用了EventWaitHandle的Reset方法，将EventWaitHandle对象自动从终止状态置回了非终止状态，所以这种模式叫AutoReset模式。所以如果有若干线程被EventWaitHandle对象的WaitOne方法阻塞了，每调用一次EventWaitHandle对象的Set方法将EventWaitHandle对象置为终止状态后，只能释放一个被阻塞的线程，然后EventWaitHandle对象又会被置为非终止状态。如果EventWaitHandle对象的Set方法之后又被调用了一次，剩下那些被阻塞的线程中，又会有一个线程被释放。所以如果有8个被WaitOne方法阻塞的线程，那么需要调用次EventWaitHandle对象的Set方法8次，才能让所有线程都得到释放。需要注意的一点就是MSDN中有提到：如果两次EventWaitHandle对象的Set方法调用非常接近，以至于当第一次调用Set方法后，被阻塞的线程还没有来得及释放，第二次Set调用又开始了，那么这两次Set方法的调用只会让一个被阻塞的线程被释放，也就是说如果两次Set方法的调用过于接近，那么就相当于只调用了一次。原因就是因为由于两次Set调用过于接近，当第一次Set调用后，其释放的线程还没有完全被释放，即EventWaitHandle对象还没有被置回非终止状态，第二次Set调用又开始了，又要求EventWaitHandle对象变成终止状态去释放剩余的阻塞线程，但是问题是现在EventWaitHandle对象本来就处于终止状态，并且第一次Set调用后的那个被释放的线程还没有被完全释放，所以现在不能去释放剩余的阻塞线程。之后待第一次Set调用后的那个被释放线程完全释放后，由于EventWaitHandle对象处于AutoReset模式，所以现在EventWaitHandle对象才会被置回非终止状态，那么就相当于第二次Set调用就白白浪费了一次机会去将EventWaitHandle对象置为终止状态去释放剩余的阻塞线程。
- 在ManualReset模式下，当EventWaitHandle对象被置为终止状态时，释放一个被WaitOne阻塞的线程后，其状态不会改变，仍然处于终止状态，所以当ManualReset模式下EventWaitHandle对象处于终止状态时，会连续释放所有被WaitOne方法阻塞的线程，直到手动调用其Reset方法将其置回非终止状态。所以这种模式叫ManualReset模式。

### AutoResetEvent 与 ManualResetEvent

**AutoResetEvent** 允许线程通过发信号互相通信。 通常，当线程需要独占访问资源时使用该类。

线程通过调用 AutoResetEvent 上的 WaitOne 来等待信号。 如果 AutoResetEvent 为非终止状态，则线程会被阻止，并等待当前控制资源的线程通过调用 Set 来通知资源可用。

调用 Set 向 AutoResetEvent 发信号以释放等待线程。 AutoResetEvent 将保持终止状态，直到一个正在等待的线程被释放，然后自动返回非终止状态。 如果没有任何线程在等待，则状态将无限期地保持为终止状态。

如果当 AutoResetEvent 为终止状态时线程调用 WaitOne，则线程不会被阻止。 AutoResetEvent 将立即释放线程并返回到非终止状态。

**ManualResetEvent** 允许线程通过发信号互相通信。 通常，此通信涉及一个线程在其他线程进行之前必须完成的任务。

当一个线程开始一个活动（此活动必须完成后，其他线程才能开始）时，它调用 Reset 以将 ManualResetEvent 置于非终止状态。 此线程可被视为控制 ManualResetEvent。 调用 ManualResetEvent 上的 WaitOne 的线程将阻止，并等待信号。 当控制线程完成活动时，它调用Set 以发出等待线程可以继续进行的信号。 并释放所有等待线程。

一旦它被终止，ManualResetEvent 将保持终止状态，直到它被手动重置。 即对 WaitOne 的调用将立即返回。

可以通过将布尔值传递给构造函数来控制 ManualResetEvent 的初始状态，如果初始状态处于终止状态，为 true；否则为 false。

ManualResetEvent 也可以同 staticWaitAll 和 WaitAny 方法一起使用。

#### 比喻

如果把每个线程比作一辆汽车的话，**AutoResetEvent**和**ManualResetEvent**就是公路上的收费站。

其中：

**Reset** 关闭收费站车闸禁止通行（拦截车辆才好收费）；

**WaitOne** 收费员等待下一辆车辆过来（然后收费）；

**Set**    开启收费站车闸放行（交钱了就让过去）。 

#### 区别

既然**AutoResetEvent**和**ManualResetEvent**都是收费站，那么它们之间有什么不同之处吗？

顾名思义，**Auto**即自动，**Manual**即手动，而**Reset**根据上面的比喻表示关闭车闸，也就是前者可自动关闭车闸，后者需手动关闭车闸。

**自动关闭车闸**：即一辆车交钱通过后，车闸会自动关闭，然后再等待下一辆车过来交费。即每辆车都要经过这么几个步骤：被阻 > 交费 > 通行 > 车闸关闭

**手动关闭车闸**：车闸打开后，车闸不会自动关闭，如果不手动关闭车闸（即调用**ManualResetEvent.Reset()**方法）的话，车辆会一辆接一辆地通过…… 

所以**WaitOne**收费操作取决于车闸是否关闭（**Reset**)，如果车闸是开启的，**WaitOne**的收费愿望只能落空，收费站形同虚设。