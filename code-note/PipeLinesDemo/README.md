## System.IO.Pipelines: .NET高性能IO

> 它非常适合那些在IO代码中复杂却普遍的痛点；使我们可以替换掉那些丑陋的封装(kludge)、变通(workaround)或妥协(compromise)——用一个在框架中设计优雅的专门的解决方案。

### 什么是Pipelines

它们实现对一个二进制流解耦、重叠(overlapped)的读写访问，包括缓冲区管理(池化，回收)，线程感知，丰富的积压控制，和通过背压达到的溢出保护——所有这些都基于一个围绕非连续内存设计的 API

PipeReader有两个核心API `ReadAsync`和`AdvanceTo`。`ReadAsync`获取Pipe数据，`AdvanceTo`告诉PipeReader不再需要这些缓冲区，以便可以丢弃它们（例如返回到底层缓冲池）。

