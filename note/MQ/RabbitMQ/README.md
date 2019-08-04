## RabbitMQ

### 简介

RabbitMQ是实现了高级消息队列协议（AMQP）的开源消息代理软件（亦称面向消息的中间件）。RabbitMQ服务器是用Erlang语言编写的，而集群和故障转移是构建在开放电信平台架构上的。所有主要的编程语言均有与代理接口通信的客户端库。

AMQP，即Advanced Message Queuing Protocol，高级消息队列协议，是应用层协议的一个开放标准，为面向消息的中间件设计。消息中间件主要用于组件之间的解耦，消息的发送者无需知道消息的使用者的存在，反之亦然。

### 架构

<div>
    <image src="/res/img/1.png"></image>
</div>

- RabbitMQ Server：也叫 broker server，它不是运送食物的卡车，而是一种传输服务。它的角色是维护一条从Producer 到 Consumer 的线路，保证数据能够按照指定的方式进行传输。
- Producer：数据的发送方。产生消息并将其发送给 RabbitMQ 。
- Consumer：数据的接收方。
- Exchanges：消息交换机，它指定消息按什么规则，路由到哪个队列。
- Quenues：消息队列载体，每个消息都会被投入到一个或多个队列。
- Bindings：绑定，它的作用就是把exchange和queue按照路由规则绑定起来。
- Routing Key：路由关键字，exchange根据这个关键字进行消息投递。
- Connection：就是一个TCP连接。Producer和Consumer都是通过TCP连接到RabbitMQ Server的。
- Channel：虚拟连接。它建立在上述的TCP连接中。数据流动都是在Channel中进行的。也就是说，一般情况下是程序起始建立TCP连接，第二步就是建立这个Channel。
- Vhost：虚拟主机，一个broker里可以开设多个Vhost，用作不同用户的权限分离。每个 virtual host 本质上都是一个RabbitMQ Server，拥有它自己的queue，exchange，和 bings rule 等等。这保证了可以在多个不同的application中使用RabbitMQ。