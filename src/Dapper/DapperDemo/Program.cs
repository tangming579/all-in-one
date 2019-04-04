using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection con = new MySqlConnection("server=127.0.0.1;database=test;uid=root;pwd=123456;charset=utf8;");
            //新增数据
            con.Execute("insert into user values(null, '测试', '18312345678', '河北','test')");
            ////新增数据返回自增id
            var id = con.QueryFirst<int>("insert into user values(null, '测试2', '18312345678', '河北','test2');select last_insert_id();");
            ////修改数据
            con.Execute("update user set UserName = 'infly123' where Id = @Id", new { Id = id });
            //查询数据
            var list = con.Query<User>("select * from user");
            foreach (var item in list)
            {
                Console.WriteLine($"用户名：{item.username} 链接：{item.address}");
            }
            //删除数据
            con.Execute("delete from user where Id = @Id", new { Id = id });
            Console.WriteLine("删除数据后的结果");
            list = con.Query<User>("select * from user");
            foreach (var item in list)
            {
                Console.WriteLine($"用户名：{item.username} 链接：{item.address}");
            }
            Console.ReadKey();
        }

        public class User
        {
            public string id { get; set; }
            public string name { get; set; }
            public string phone { get; set; }
            public string address { get; set; }
            public string username { get; set; }
        }
    }
}
