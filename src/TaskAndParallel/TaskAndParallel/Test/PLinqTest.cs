using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskAndParallel.Test
{
    public class PLinqTest
    {
        public void Demo1()
        {
            var dic = LoadData();
            var query1 = (from n in dic.Values.AsParallel()
                          where n.Age > 20 && n.Age < 25
                          select n).ToList();
            Console.WriteLine("默认的时间排序如下：");
            query1.Take(10).ToList().ForEach((i) =>
            {
                Console.WriteLine(i.CreateTime);
            });

            var query2 = (from n in dic.Values.AsParallel()
                          where n.Age > 20 && n.Age < 25
                          orderby n.CreateTime descending
                          select n).ToList();

            Console.WriteLine("排序后的时间排序如下：");
            query2.Take(10).ToList().ForEach((i) =>
            {
                Console.WriteLine(i.CreateTime);
            });

        }

        public static ConcurrentDictionary<int, Student> LoadData()
        {
            ConcurrentDictionary<int, Student> dic = new ConcurrentDictionary<int, Student>();

            //预加载1500w条记录
            Parallel.For(0, 15000000, (i) =>
            {
                var single = new Student()
                {
                    ID = i,
                    Name = "hxc" + i,
                    Age = i % 151,
                    CreateTime = DateTime.Now.AddSeconds(i)
                };
                dic.TryAdd(i, single);
            });

            return dic;
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
