using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WindowsServiceDemo.QuartzJob;

namespace WindowsServiceDemo
{
    public partial class JobManager : ServiceBase
    {
        public JobManager()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var path = Path.Combine("d://service.txt");
            File.AppendAllText(path, "Start " + DateTime.Now.ToString() + "\r\n");
            RunScheduler();
        }

        protected override void OnStop()
        {
            var path = Path.Combine("d://service.txt");
            File.AppendAllText(path, "Stop " + DateTime.Now.ToString() + "\r\n");
        }

        public async Task WriteAsync()
        {
            while (true)
            {
                await Task.Delay(TimeSpan.FromSeconds(2)).ConfigureAwait(false);
                //var path = Path.Combine("d://service.txt");
                //File.AppendAllText(path, "Process " + DateTime.Now.ToString() + "\r\n");
            }
        }
        private static async Task RunScheduler()
        {
            // 创建作业调度器
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();

            // 启动调度器
            await scheduler.Start();


            //==========例子1（简单使用）===========
            // 创建作业
            IJobDetail job = JobBuilder.Create<HelloJob>()
                .WithIdentity("job1", "group1")
                .Build();

            // 创建触发器，每10s执行一次
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(10)
                    .RepeatForever())
                .Build();

            // 加入到作业调度器中
            await scheduler.ScheduleJob(job, trigger);


            //==========例子2 (执行时 作业数据传递，时间表达式使用)===========
            IJobDetail job2 = JobBuilder.Create<CronJob>()
                .WithIdentity("myJob", "group1")
                .UsingJobData("jobSays", "Hello World!")
                .Build();


            ITrigger trigger2 = TriggerBuilder.Create()
                .WithIdentity("mytrigger", "group1")
                .StartNow()
                .WithCronSchedule("/5 * * ? * *")    //时间表达式，5秒一次     
                .Build();


            await scheduler.ScheduleJob(job2, trigger2);
        }
    }
}
