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
            Scheduler = new StdSchedulerFactory().GetScheduler();
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
