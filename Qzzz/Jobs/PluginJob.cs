using System;
using System.Collections.Generic;

using Quartz;
using Qzzz.Plugin;

namespace Qzzz.Jobs
{
    public class PluginJob : IJob
    {
        public static Dictionary<string, QzzzPlugin> PluginsList = new Dictionary<string, QzzzPlugin>();

        public void Execute(IJobExecutionContext context)
        {
            try {
                var key = context.JobDetail.JobDataMap["PluginId"] as string;
                if (key == null)
                    return;

                var plugin = PluginsList[key];

                var pluginContext = plugin.PluginContext;
                plugin.Plugin.Execute(pluginContext);

                if (!plugin.Plugin.Pause(pluginContext))
                    return;

                new JobManager(context.Scheduler).PauseJob(context.JobDetail.Key);
                Log.Warn(string.Format("[JobManager] Job {0} paused.", plugin.PluginMeta.Name));
            }
            catch (Exception e) {
                Log.Error(e.Message);
            }
        }
    }
}
