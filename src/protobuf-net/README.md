## Protocol Buffer使用

### 简介

​	protocolbuffer是google 的一种数据交换的格式，它独立于语言，独立于平台。它是一种类似于xml、json等类似作用的交互格式。由于它是一种二进制的格式，比使用 xml 进行数据交换快许多。

PB具有三个版本：

1. Google官方版本：<https://github.com/google/protobuf/tree/master/csharp>（谷歌官方开发、比较晦涩，主库名字：Google.ProtoBuf.dll）
2. .Net社区版本：<https://github.com/mgravell/protobuf-net>（.Net社区爱好者开发，写法上比较符合.net上的语法习惯，主库名字：protobuf-net.dll）
3. .Net社区版本（二）：<https://github.com/jskeet/protobuf-csharp-port>（据说是由谷歌的.net员工为.net开发，在官方没有出来csharp的时候开发，到发博文时还在维护，主库名字：Google.ProtocolBuffers.dll）

### proto2与proto3

总的来说，prot3比prot2支持更多语言但更简洁。去掉了一些复杂的语法和特性，更强调约定而弱化语法。如果首次使用Protobuf，建议使用proto3

1. 在第一行非空白费注释行，必须写：

   ```protobuf
   syntax = "proto3"
   ```

2. 字段移除了 “required” ，并把 “optional” 改名为 “singular”

   在proto2中 required 也是不推荐使用的。proto3则直接移除了该规则。

3. “repeated” 字段默认采用 packed 编码

   在proto2中，需要明确使用  [packed=true] 来为字段指定比较紧凑的 packed 编码方式

4. 语言增加 Go、Ruby、JavaNano 支持；

5. 移除了default选项；

### Google.ProtoBuf.dll使用

1. Nuget安装Google.Protobuf和Google.Protobuf.Tools

2. 定义Proto文件，需要注意的是,proto文件之间可以互相引用,要正常使用,必须把所有相关的proto文件都准备好

3. 生成解码器 建立两个文件夹,一个名为src,一个名为gen 把准备好的proto文件全部放到src中，命令行找到protoc.exe 工具并执行

   ```
   .\protoc.exe --proto_path=src --csharp_out=gen xx.proto 
   ```

4. 执行实例：

   ```c#
   class Program
       {
           static void Main(string[] args)
           {
               byte[] bytes;
               SearchRequest request = new SearchRequest();
               request.PageNumber = 1;
               request.ResultPerPage = 10;
               request.Query = "最新";
               using (MemoryStream stream = new MemoryStream())
               {
                   // Save the person to a stream
                   request.WriteTo(stream);
                   bytes = stream.ToArray();
               }
               SearchRequest copy = SearchRequest.Parser.ParseFrom(bytes);
           }
       }
   ```

### protobuf-net.dll使用

有三种方式使用protobuf：

1. 手动方式
2. 动态方式
3. proto文件方式

**手动方式**

```c#
[ProtoContract]
    class Person
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public Address Address { get; set; }
    }
    [ProtoContract]
    class Address
    {
        [ProtoMember(1)]
        public string Line1 { get; set; }
        [ProtoMember(2)]
        public string Line2 { get; set; }
    }
```

**动态方式**

未尝试

**proto文件方式**

1. 定义protobuf文件：

   ```protobuf
   syntax = "proto3";
   import "other_protos.proto";
   message SearchRequest{
   	string query=1;
   	int32 page_number=2;// 最终返回的页数
   	int32 result_per_page=3;// 每页返回的结果数
   	enum Corpus{
   		UNIVERSAL=0;
   		WEB=1;
   		IMAGES=2;
   		LOCAL=3;
   		NEWS=4;
   	}
   	Corpus corpus=4;
   }
   message SearchResponse{
   	repeated Result result=1;
   	repeated Code code=2;
   }
   message Result{
   	string url=1;
   	string title=2;
   	repeated string snippets=3;
   }
   ```

2. 使用protogen.exe 生成cs文件：

   ```
   protogen.exe -i:protos\ReturnMessage.proto -o:cs\ReturnMessage.cs
   protogen.exe -i:protos\Login.proto -o:cs\Login.cs
   protogen.exe -i:protos\Test.proto -o:cs\Test.cs
   ```

3. 使用代码：

   ```c#
   public static void Methond2()
           {
               var person = new Person
               {
                   Id = 12345,
                   Name = "Fred",
                   Address = new Address
                   {
                       Line1 = "Flat 1",
                       Line2 = "The Meadows"
                   }
               };
               var byt = GetByte(person);
               var instance = GetInstance<Person>(byt);
           }
           public static byte[] GetByte<T>(T item) where T : class, new()
           {
               using (MemoryStream ms = new MemoryStream())
               {
                   Serializer.Serialize(ms, item);
                   byte[] actual = ms.ToArray();
                   return actual;
               }
           }
           public static T GetInstance<T>(byte[] item) where T : class, new()
           {
               using (MemoryStream ms = new MemoryStream(item))
               {
                   var instance = Serializer.Deserialize<T>(ms);
                   return instance;
               }
           }
   ```
