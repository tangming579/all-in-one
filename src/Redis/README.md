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



### 其他特性



### 分布式集群部署



### 持久化