using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Quartz_CSharp.Job;

namespace Quartz_CSharp
{
    class Program
    {
        private static IScheduler scheduler;

        static void Main(string[] args)
        {
            RunProgram().GetAwaiter().GetResult();

            Console.ReadKey();
            scheduler.Shutdown();
        }

        private static async Task RunProgram()
        {
            try
            {
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                scheduler = await factory.GetScheduler();

                await scheduler.Start();

                IJobDetail job = JobBuilder.Create<TimeSpanJob>()
                    .WithIdentity("job1", "group1")
                    .Build();

                //每5秒执行一次
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("trigger1", "group1")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                        .WithIntervalInSeconds(5)
                        .RepeatForever())
                    .Build();

                IJobDetail cronJob = JobBuilder.Create<CronJob>()
                    .WithIdentity("job2", "group1")
                    .Build();

                ITrigger trigger2 = TriggerBuilder.Create()
                    .WithIdentity("trigger3", "group1")
                    .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(17, 21))
                    .ForJob(cronJob)
                    .Build();

                await scheduler.ScheduleJob(job, trigger);
                await scheduler.ScheduleJob(cronJob, trigger2);

            }
            catch (SchedulerException se)
            {
                await scheduler.Shutdown();
                await Console.Error.WriteLineAsync(se.ToString());
            }
        }
    }
}
