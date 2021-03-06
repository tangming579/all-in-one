## RabbitMQ

### 简介

RabbitMQ是实现了高级消息队列协议（AMQP）的开源消息代理软件（亦称面向消息的中间件）。RabbitMQ服务器是用Erlang语言编写的，而集群和故障转移是构建在开放电信平台架构上的。所有主要的编程语言均有与代理接口通信的客户端库。

AMQP，即Advanced Message Queuing Protocol，高级消息队列协议，是应用层协议的一个开放标准，为面向消息的中间件设计。消息中间件主要用于组件之间的解耦，消息的发送者无需知道消息的使用者的存在，反之亦然。

### 架构

<div>
    <image src="res/img/1.png"></image>
</div>

- RabbitMQ Server：也叫 broker server，它不是运送食物的卡车，而是一种传输服务。它的角色是维护一条从Producer 到 Consumer 的线路，保证数据能够按照指定的方式进行传输。

- Producer：数据的发送方。产生消息并将其发送给 RabbitMQ 。

- Consumer：数据的接收方。

- Exchanges：消息交换机，它指定消息按什么规则，路由到哪个队列。

- Quenues：消息队列载体，每个消息都会被投入到一个或多个队列。

- Bindings：Exchange和Queue之间的虚拟连接，binding中可以包含routing key

- Routing Key：路由关键字，exchange根据这个关键字进行消息投递。

- Connection：就是一个TCP连接。Producer和Consumer都是通过TCP连接到RabbitMQ Server的。

- Channel：虚拟连接。它建立在上述的TCP连接中。数据流动都是在Channel中进行的。也就是说，一般情况下是程序起始建立TCP连接，第二步就是建立这个Channel。

- Vhost：虚拟主机，一个broker里可以开设多个Vhost，用作不同用户的权限分离。每个 virtual host 本质上都是一个RabbitMQ Server，拥有它自己的queue，exchange，和 bings rule 等等。这保证了可以在多个不同的application中使用RabbitMQ。

  <div>
      <image src="res/img/vhost.png"></image>
  </div>

### Channel的选择

为什么使用Channel，而不是直接使用TCP连接？

对于OS来说，建立和关闭TCP连接是有代价的，频繁的建立关闭TCP连接对于系统的性能有很大影响，而且TCP的连接数也有限制，这也限制了系统处理高并发的能力。但是，在TCP连接中建立Channel是没有上述代价的。对于Producer或者Consumer来说，可以并发的使用多个Channel进行Publish或者Receive。

### 消息队列的执行过程

1. 客户端连接到消息队列服务器，打开一个Channel。
2. 客户端声明一个Exchange，并设置相关属性。
3. 客户端声明一个Queue，并设置相关属性。
4. 客户端使用Routing key，在Exchange和Queue之间建立好绑定关系。
5. 客户端投递消息到Exchange。

Exchange接收消息后，根据消息的key和已经设置的Binding，进行信息路由，将消息投递到一个或多个消息队列里。有三种类型的Exchanges：direct、fanout、topic，每个实现了不同的路由算法（routing algorithm）：

| Name（交换机类型）            | 预声明的默认名称                        |
| ----------------------------- | --------------------------------------- |
| Direct exchange（直连交换机） | (Empty string) and amq.direct           |
| Fanout exchange（扇型交换机） | amq.fanout                              |
| Topic exchange（主题交换机）  | amq.topic                               |
| Headers exchange（头交换机）  | amq.match (and amq.headers in RabbitMQ) |

**fanout（扇形交换机）**

fanout类型的Exchange路由规则非常简单，它会把所有发送到该Exchange的消息路由到所有与它绑定的Queue中。

<div>
    <image src="res/img/fanout.png"></image>
</div>

fanout不需要处理Routing key。只需要简单的将队列绑定到Exchange上。这样发送到Exchange的消息会被转发到与该交换机绑定的所有队列上。类似子网广播，每台子网内的主机都获得一份复制的消息。

**direct（直连交换机）**

direct类型的Exchange路由规则也很简单，它会把消息路由到那些binding key与routing key完全匹配的Queue中。

<div>
    <image src="res/img/direct.png"></image>
</div>



**topic（主题交换机）**

通过对消息的路由键和队列到交换机的绑定模式之间的匹配，将消息路由给一个或多个队列。比如符号”#”匹配一个或多个词，符号””匹配正好一个词。例如”abc.#”匹配”abc.def.ghi”，”abc.”只匹配”abc.def”。

<div>
    <image src="res/img/topic.png"></image>
</div>

使用案例：

- 分发有关于特定地理位置的数据，例如销售点
- 由多个工作者（workers）完成的后台任务，每个工作者负责处理某些特定的任务
- 股票价格更新（以及其他类型的金融数据更新）
- 涉及到分类或者标签的新闻更新（例如，针对特定的运动项目或者队伍）
- 云端的不同种类服务的协调
- 分布式架构/基于系统的软件封装，其中每个构建者仅能处理一个特定的架构或者系统。

### 持久化

1. exchange持久化，在声明时指定durable => true
2. queue持久化，在声明时指定durable => true
3. 消息持久化，在投递时指定delivery_mode=> 2（1是非持久化）

如果exchange和queue都是持久化的，那么它们之间的binding也是持久化的。如果exchange和queue两者之间有一个持久化，一个非持久化，就不允许建立绑定。

注意：一旦创建了队列和交换机，就不能修改其标志了。例如，如果创建了一个non-durable的队列，然后想把它改变成durable的，唯一的办法就是删除这个队列然后重现创建。

### Web管理界面

打开浏览器，输入 http://[server-name\]:15672 如 http://localhost:15672/  ，会要求输入用户名和密码，用默认的guest/guest即可（**guest/guest用户只能从localhost地址登录，如果要配置远程登录，必须另创建用户**），确认后会出现下面界面：

<div>
    <image src="res/img/webmgr.png"></image>
</div>



### 分布式部署



### 代码示例