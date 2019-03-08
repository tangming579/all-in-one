using Microsoft.VisualStudio.TestTools.UnitTesting;
using RabbitMqLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqLib.Tests
{
    [TestClass()]
    public class Class1Tests
    {
        [TestMethod()]
        [DataRow(1, 2)]
        public void SumTest(int a, int b)
        {
            Class1 cla = new Class1();
            cla.Sum(a, b);
        }

        [TestMethod()]
        [DataRow(1, 2)]
        [DataRow(1, 0)]
        public void DivideTest(int a, int b)
        {
            Class1 cla = new Class1();
            cla.Divide(a, b);
        }
    }
}