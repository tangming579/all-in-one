## RabbitMQ

### 简介

RabbitMQ是实现了高级消息队列协议（AMQP）的开源消息代理软件（亦称面向消息的中间件）。RabbitMQ服务器是用Erlang语言编写的，而集群和故障转移是构建在开放电信平台架构上的。所有主要的编程语言均有与代理接口通信的客户端库。

AMQP，即Advanced Message Queuing Protocol，高级消息队列协议，是应用层协议的一个开放标准，为面向消息的中间件设计。消息中间件主要用于组件之间的解耦，消息的发送者无需知道消息的使用者的存在，反之亦然。

应用场景架构：

<div>
    <image src="/res/img/1.png"></image>
</div>

- RabbitMQ Server：也叫 broker server，它不是运送食物的卡车，而是一种传输服务。它的角色是维护一条从Producer 到 Consumer 的线路，保证数据能够按照指定的方式进行传输。
- Producer：数据的发送方。产生消息并将其发送给 RabbitMQ 。
- Consumer：数据的接收方。
- Exchanges：
- Quenues：
- Bindings：
- Routing Key：
- Connection：
- Channel：
- Vhost：