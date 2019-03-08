using RabbitMqLib.MQHelloWorld;
using RabbitMqLib.WorkQueues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitmqCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Send send = new Send();
            //send.Start();

            //Receive rec = new Receive();
            //rec.Start();

            NewTask task = new NewTask();
            task.Start();

            //Worker worker = new Worker();
            //worker.Start();
        }
    }
}
