using Microsoft.VisualStudio.TestTools.UnitTesting;
using RabbitMqLib.MQHelloWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqLib.MQHelloWorld.Tests
{
    [TestClass()]
    public class ReceiveTests
    {
        [TestMethod()]
        public void StartTest()
        {
            Send send = new Send();
            send.Start();
        }
    }
}