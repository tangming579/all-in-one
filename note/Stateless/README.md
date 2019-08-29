## Stateless

Stateless 是一个基于 .NET 的开源状态机库，使用它可以很轻松的在 .NET 中创建状态机和以状态机为基础的轻量级工作流。

GitHub：https://github.com/dotnet-state-machine/stateless

```c#
//初始化状态机，默认状态为挂机状态（offHook）
var phoneCall = new StateMachine<State, Trigger>(State.OffHook);

//当电话处于挂机状态时，如果触发被呼叫事件，电话的状态会变为响铃状态(Ringing)
phoneCall.Configure(State.OffHook)
    .Permit(Trigger.CallDialled, State.Ringing);

//当电话处于响铃状态时，如果触发通过连接事件，电话的状态会变为已连接状态(Connected)
phoneCall.Configure(State.Ringing)
    .Permit(Trigger.CallConnected, State.Connected);

//当电话处于已连接状态时，系统会开始计时，已连接状态变为其他状态时，系统会结束计时
//当电话处于已连接状态时，如果触发留言事件，电话的状态会变为挂机状态(OffHook)
//当电话处于已连接状态时，如果触发挂起事件，电话的状态会变为挂起状态(OnHold)
phoneCall.Configure(State.Connected)
    .OnEntry(() => StartCallTimer())
    .OnExit(() => StopCallTimer())
    .Permit(Trigger.LeftMessage, State.OffHook)
    .Permit(Trigger.PlacedOnHold, State.OnHold);

//触发了一个呼叫事件
phoneCall.Fire(Trigger.CallDialled);
//触发呼叫事件之后，电话的状态变更为响铃状态,此处断言是正确的
Assert.AreEqual(State.Ringing, phoneCall.State);
```

### 状态分级

如下，OnHold 状态是 Connected 状态的子状态，这意味着 OnHold 状态时也处于 Connected 状态

```
phoneCall.Configure(State.OnHold)
	.SubstateOf(State.Connected)
	.Permit(Trigger.TakenOfHold, State.Connected)
	.Permit(Trigger.PhoneHurledAgainstWall, State.PhoneDestroyed);
```

### Entry/Exit Events

当电话处于 Connected 状态时，StartCallTimer() 方法将会执行。当电话处于 Completes 时，StopCallTimer() 方法会被执行。

调用可以在 Connected 和 OnHold 之间来回切换，但却不会重复调用StartCallTimer() 和 StopCallTimer() 方法。因为 OnHold 状态是 Connected 的子状态。

### 额外存储

Stateless 被设计为可以嵌入代码的 Models 中。例如，一些 ORM 会要求定义一些用于对象关系映射的数据，通过UI层与储存位置进行绑定。 StateMachine 构造函数可以接受用于读取和写入状态值的函数参数：

```c#
var stateMachine = new StateMachine<State, Trigger>(
    () => myState.Value,
    s => myState.Value = s);
```

在这个示例中，StateMachine 将会使用 myState 对象来存储状态。