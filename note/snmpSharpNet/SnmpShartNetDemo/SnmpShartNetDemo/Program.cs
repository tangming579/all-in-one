using SnmpSharpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnmpShartNetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //监控设备的ip
            string ip = "127.0.0.1";
            //监控设备的社团名
            String community = "public";

            SimpleSnmp snmp = new SimpleSnmp(ip, community);

            //监控项oid和对应的名称
            Dictionary<string, string> Oids = new Dictionary<string, string>();
            Oids.Add("1.3.6.1.2.1.25.2.2.0", "系统物理内存");
            Oids.Add("1.3.6.1.2.1.25.1.5.0", "主机会话数");
            Oids.Add("1.3.6.1.2.1.25.1.6.0", "系统进程数");

            //通过SNMP v2协议获取信息
            Dictionary<Oid, AsnType> results = snmp.Get(SnmpVersion.Ver2, Oids.Keys.ToArray());

            //显示获取到的信息
            foreach (var result in results)
            {
                var oid = result.Key.ToString().Trim('}', '{');
                if (Oids.ContainsKey(oid))
                    Console.WriteLine($"{Oids[result.Key.ToString()]}  {result.Value}");
            }

            Console.ReadKey();
        }
    }
}
