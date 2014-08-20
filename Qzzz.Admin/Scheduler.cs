using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;

namespace Qzzz.Admin
{
    public static class Scheduler
    {
        private static readonly IScheduler _scheduler = GetScheduler();

        private static IScheduler GetScheduler()
        {
            var properties = new NameValueCollection();
            properties["quartz.scheduler.instanceName"] = "AspNetClientScheduler";
            properties["quartz.scheduler.proxy"] = "true";
            properties["quartz.scheduler.proxy.address"] = "tcp://127.0.0.1:555/UpdateScheduler";
            return new StdSchedulerFactory(properties).GetScheduler();
        }

        public static BoolResult<IEnumerable<SchedulerJob>> GetJobs()
        {
            var result = new BoolResult<IEnumerable<SchedulerJob>>() { IsSuccess = true };
            try {
                var keys = _scheduler.GetJobKeys(GroupMatcher<JobKey>.AnyGroup());
                result.Result = keys.Select(u => new SchedulerJob(u.Name, u.Group));
            }
            catch (Exception ex) {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static string GetJobStatus(TriggerKey triggerKey)
        {
            var triggerState = _scheduler.GetTriggerState(triggerKey);
            return Enum.GetName(typeof(TriggerState), triggerState);
        }

        public static BoolResult PauseJob(JobKey jobKey)
        {
            var result = new BoolResult() { IsSuccess = true };
            try {
                _scheduler.PauseJob(jobKey);
            }
            catch (Exception ex) {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static BoolResult DeleteJob(JobKey jobKey)
        {
            var result = new BoolResult() { IsSuccess = true };
            try {
                _scheduler.DeleteJob(jobKey);
            }
            catch (Exception ex) {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static BoolResult ResumeJob(JobKey jobKey)
        {
            var result = new BoolResult() { IsSuccess = true };
            try {
                _scheduler.ResumeJob(jobKey);
            }
            catch (Exception ex) {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
