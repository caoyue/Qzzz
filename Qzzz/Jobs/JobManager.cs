using System;
using Quartz;
using Qzzz.Plugin;

namespace Qzzz.Jobs
{
    public class JobManager
    {
        private readonly IScheduler _scheduler;

        public JobManager(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public void AddJob(QzzzPlugin plugin)
        {
            var job = GetJobDetail(plugin);
            var trigger = GetTrigger(plugin);
            _scheduler.ScheduleJob(job, trigger);
        }

        public void DeleteJob(QzzzPlugin plugin)
        {
            var id = GetId(plugin);
            _scheduler.DeleteJob(new JobKey(id, "PluginGroup"));
        }

        public void DeleteJob(JobKey jobKey)
        {
            _scheduler.DeleteJob(jobKey);
        }

        public void PauseJob(QzzzPlugin plugin)
        {
            var id = GetId(plugin);
            _scheduler.PauseJob(new JobKey(id, "PluginGroup"));
        }

        public void PauseJob(JobKey jobKey)
        {
            _scheduler.PauseJob(jobKey);
        }

        public void UpdateJob(QzzzPlugin plugin)
        {
            var job = GetJobDetail(plugin);
            _scheduler.AddJob(job, true);

            var id = GetId(plugin);
            var trigger = GetTrigger(plugin);
            _scheduler.RescheduleJob(new TriggerKey(id, "PluginGroup"), trigger);
        }

        private string GetId(QzzzPlugin plugin)
        {
            return string.Format("{0}_{1}", plugin.PluginMeta.Name, plugin.PluginMeta.Id.ToString());
        }

        private IJobDetail GetJobDetail(QzzzPlugin plugin)
        {
            var id = GetId(plugin);
            return JobBuilder.Create<PluginJob>()
                .UsingJobData("PluginId", id)
                .WithIdentity(id, "PluginGroup")
                .WithDescription(plugin.PluginMeta.Description)
                .Build();
        }

        private ITrigger GetTrigger(QzzzPlugin plugin)
        {
            var builder = TriggerBuilder.Create()
                .WithIdentity(GetId(plugin), "PluginGroup")
                .WithDescription(plugin.PluginMeta.Description);

            if (plugin.PluginMeta.StartAt.HasValue) {
                builder = builder.StartAt(plugin.PluginMeta.StartAt.Value);
            }
            if (plugin.PluginMeta.EndAt.HasValue) {
                builder = builder.EndAt(plugin.PluginMeta.EndAt.Value);
            }
            return builder.WithCronSchedule(plugin.PluginMeta.CronExpression).Build();
        }
    }
}
