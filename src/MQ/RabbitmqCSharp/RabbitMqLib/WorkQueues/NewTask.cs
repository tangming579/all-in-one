using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqLib.WorkQueues
{
    public class NewTask
    {
        public void Start()
        {
            var factory = new ConnectionFactory();
            factory.HostName = "154.8.184.140";
            factory.UserName = "admin";//用户名
            factory.Password = "admin";//密码
            factory.Port = 5672;
            factory.VirtualHost = "/";
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "task_queue",
                                     durable: true,  //队列持久化
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

               

                //消息持久化
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                for(int i = 0; i < 20; i++)
                {
                    var message = GetMessage(new string[] { "hello"+i });
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "",
                                     routingKey: "task_queue",
                                     basicProperties: properties,
                                     body: body);
                    Console.WriteLine(" [x] Sent {0}", message);
                }
               
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}
