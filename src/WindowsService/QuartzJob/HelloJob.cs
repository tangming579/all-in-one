using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceDemo.QuartzJob
{
    public class HelloJob : IJob
    {
        /// <summary>
        /// 作业调度定时执行的方法
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync("Hello QuartzNet...");            
        }
    }
}
