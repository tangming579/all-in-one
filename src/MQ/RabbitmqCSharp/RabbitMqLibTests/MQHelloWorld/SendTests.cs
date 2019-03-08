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
    public class SendTests
    {
        [TestMethod()]
        public void StartTest()
        {
            Receive receive = new Receive();
            receive.Start();
        }
    }
}