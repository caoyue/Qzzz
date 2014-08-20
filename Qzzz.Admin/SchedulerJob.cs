using System;
using Quartz;

namespace Qzzz.Admin
{
    public class SchedulerJob
    {
        public SchedulerJob(string name, string group)
        {
            this.Name = name;
            this.Group = group;
        }

        public string Name { get; set; }

        public string Group { get; set; }

        public string ReadName
        {
            get { return Name.Length > 33 ? Name.Remove(Name.Length - 33) : Name; }
        }

        public string Status
        {
            get { return Scheduler.GetJobStatus(new TriggerKey(Name, Group)); }
        }

        public BoolResult Pause()
        {
            return Scheduler.PauseJob(new JobKey(Name, Group));
        }

        public BoolResult Delete()
        {
            return Scheduler.DeleteJob(new JobKey(Name, Group));
        }

        public BoolResult Resume()
        {
            return Scheduler.ResumeJob(new JobKey(Name, Group));
        }
    }
}
