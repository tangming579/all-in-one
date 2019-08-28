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

