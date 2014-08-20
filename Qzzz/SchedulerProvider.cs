using System.Collections.Specialized;
using Quartz;
using Quartz.Impl;
using Qzzz.Jobs;

namespace Qzzz
{
    public class SchedulerProvider
    {
        private static readonly IScheduler Scheduler;

        static SchedulerProvider()
        {
            var properties = new NameValueCollection();
            properties["quartz.scheduler.instanceName"] = "UpdateScheduler";

            // set thread pool info
            properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
            properties["quartz.threadPool.threadCount"] = "10";
            properties["quartz.threadPool.threadPriority"] = "Normal";

            // set remoting exporter
            properties["quartz.scheduler.exporter.type"] = "Quartz.Simpl.RemotingSchedulerExporter, Quartz";
            properties["quartz.scheduler.exporter.port"] = "555";
            properties["quartz.scheduler.exporter.bindName"] = "UpdateScheduler";
            properties["quartz.scheduler.exporter.channelType"] = "tcp";
            properties["quartz.scheduler.exporter.channelName"] = "httpQuartz";

            Scheduler = new StdSchedulerFactory(properties).GetScheduler();
        }

        public void Show()
        {
            Init(15);
            Scheduler.Start();
        }

        public void Shutdown()
        {
            Scheduler.Shutdown();
        }

        private void Init(int interval)
        {
            var job = JobBuilder.Create<QzzzJob>()
                .WithIdentity("UpdateScheduler", "QzzzGroup")
                .WithDescription("Main job")
                .Build();
            var trigger = TriggerBuilder.Create()
                .WithIdentity("UpdateScheduler", "QzzzGroup")
                .StartNow()
                .WithSimpleSchedule(s => s.WithIntervalInSeconds(interval)
                    .RepeatForever())
                .Build();
            Scheduler.ScheduleJob(job, trigger);
        }
    }
}
