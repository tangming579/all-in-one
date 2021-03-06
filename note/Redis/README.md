## Redis

### 简介

Redis 是完全开源免费的，遵守BSD协议，是一个高性能的key-value数据库。

Redis 与其他 key - value 缓存产品有以下三个特点：

- Redis支持数据的持久化，可以将内存中的数据保存在磁盘中，重启的时候可以再次加载进行使用。
- Redis不仅仅支持简单的key-value类型的数据，同时还提供list，set，zset，hash等数据结构的存储。
- Redis支持数据的备份，即master-slave模式的数据备份。

### .Net下的使用

.Net 下对Redis操作主要有两种方式：ServiceStack.Redis 与 StackExchange.Reids

1. ServiceStack.Redis：功能强大，速度快。但引用类库较多，4.0以上版本有每小时调用6000次的限制
2. StackExchange.Redis：免费开源，速度稍慢一些，没有太多依赖项，只需引用一个dll

### 数据类型

| 结构类型         | 结构存储的值                                                 | 结构的读写能力                                               |
| ---------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| String           | 可以是字符串、整数或者浮点数                                 | 对整个字符串或者字符串的其中一部分执行操作；对整数和浮点数执行自增（increment）或者自减（decrement）操作 |
| List             | 一个链表，链表上的每个节点都包含了一个字符串                 | 从脸部的两端推入或者弹出元素；根据偏移量对链表进行修剪（trim）；读取单个或者多个元素；根据值查找或者移除元素 |
| Set              | 包含字符串的无序收集器（unordered collection），并且被包含的每个字符串都是独一无二、各不相同的 | 添加、获取、移除单个元素；检查一个元素是否存在于集合中；计算交集、并集、差集；从集合里面随机获取元素 |
| Hash             | 包含键值对的无序散列表                                       | 添加、获取、移除单个键值对；获取所有键值对                   |
| ZSet（有序集合） | 字符串成员（member）与浮点数分值（score）之间的有序映射，元素的排列顺序由分值的大小决定 | 添加、获取、删除单个元素；根据分值范围（range）或者成员来获取元素 |

#### 字符串

| 命令 | 行为                                               | 举例            | 说明                     |
| ---- | -------------------------------------------------- | --------------- | ------------------------ |
| get  | 获取存储的给定健中的值                             | set hello world | 将键hello的值设置为world |
| set  | 设置存储的给定健中的值                             | get hello       |                          |
| del  | 删除存储在给定健中的值（这个命令可以用于所有类型） | del hello       |                          |

#### 列表

| 命令   | 行为                                     | 举例                 | 说明                                       |
| ------ | ---------------------------------------- | -------------------- | ------------------------------------------ |
| rpush  | 将给定值推入列表右端                     | rpush list-key item  | 向列表推入新元素，该命令返回列表长度       |
| lrange | 获取列表的给定范围上的所有值             | lrange list-key 0 -1 | 0表示第一个元素，-1表示倒数第一个元素      |
| lindex | 获取列表的给定位置上的单个元素           | lindex list-key 1    | 列出第二个元素                             |
| lpop   | 从列表的左端弹出一个值，并返回被弹出的值 | lpop list-key        | 弹出一个元素，被弹出的元素将不再存在于列表 |

#### 集合

Redis的集合和列表都可以存储多个字符串，他们之间的不同在于，列表可以存储多个相同的字符串，而集合则通过使用散列表来保证自助存储的字符串都各不相同

| 命令      | 行为                                       | 举例                     |
| --------- | ------------------------------------------ | ------------------------ |
| sadd      | 将给定元素添加到集合                       | sadd set-key item2       |
| smembers  | 返回集合包含的所有元素                     | smembers set-key         |
| sismember | 检查给定元素是否存在于集合中               | sismemeber set-key item2 |
| srem      | 如果给定的元素存在于集合中，那么移除该元素 | srem set-key item2       |

#### 散列

| 命令    | 行为                                     | 举例                          |
| ------- | ---------------------------------------- | ----------------------------- |
| hset    | 在散列里面关联起给定的键值对             | hset hash-key sub-key1 value1 |
| hget    | 获取指定的散列键的值                     | hget hash-key sub-key1        |
| hgetall | 获取散列包含的所有键值对                 | hgetall hash-key              |
| hdel    | 如果给定键存在于散列里面，那么移除这个键 | hdel hash-key sub-key2        |

#### 有序集合

有序集合和散列一样，都用于存储键值对：有序集合的键被称为成员（member），每个成员都是各不相同的；二有序集合的值被称为分值（score），分值必须为浮点数

| 命令          | 行为                                                       | 举例                                    |
| ------------- | ---------------------------------------------------------- | --------------------------------------- |
| zadd          | 将一个带有给定分值的成员添加到有序集合里面                 | zadd zset-key 728 member1               |
| zrange        | 根据元素在有序排列中所处的位置，从有序集合里面获取多个元素 | zrange zset-key 0 -1                    |
| zrangebyscore | 获取有序集合在给定分值范围内的所有元素                     | zrangebyscore zset-key 0 800 withscores |
| zrem          | 如果给定成员存在于有序集合，那么移除这个成员               | zrem zset-key member1                   |



### 其他特性

### 过期策略

过期策略通常有一下三种：

- 定时删除：每个设置过期时间的key都需要创建一个定时器，到过期时间就会立即清除。该策略可以立即清除过期的数据，对内存很友好；但是会占用大量的CPU资源去处理过期的数据，从而影响缓存的响应时间和吞吐量。

- 惰性删除：只有当访问一个key时，才会判断该key是否已过期，过期则清除。该策略可以最大化地节省CPU资源，却对内存非常不友好。极端情况可能出现大量的过期key没有再次被访问，从而不会被清除，占用大量内存。

- 定期删除：每隔一段时间，会扫描一定数量的数据库的expires字典中一定数量的key，并清除其中已过期的key。该策略是前两者的折中方案。

  定期删除可以通过：

  - 第一、配置redis.conf 的hz选项，默认为10 （即1秒执行10次，100ms一次，随机抽取一些设置了过期时间的 key，检查其是否过期，如果过期就删除。） 
  - 第二、配置redis.conf的maxmemory最大值，当已用内存超过maxmemory限定时，就会触发主动清理策略（内存淘汰机制）

Redis中同时使用了惰性过期和定期过期两种过期策略。

### 分布式集群部署



### 持久化