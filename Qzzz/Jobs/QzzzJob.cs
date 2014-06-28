using System;

using Quartz;

namespace Qzzz.Jobs
{
    public class QzzzJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            try {
                PluginLoader.Load(context.Scheduler);
            }
            catch (Exception e) {
                Log.Error(e.Message);
            }
        }
    }
}
