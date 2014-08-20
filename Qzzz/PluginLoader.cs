using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

using Newtonsoft.Json;
using Quartz;
using Quartz.Impl.Matchers;
using Qzzz.Jobs;
using Qzzz.Plugin;

namespace Qzzz
{
    public class PluginLoader
    {
        private const string ConfigName = "qzzz.json";
        private const string PluginFolderName = "Plugins";

        public static void Load(IScheduler scheduler)
        {
            var jobManager = new JobManager(scheduler);

            var allPath = GetAllPluginPath(PluginFolderName);
            foreach (var pluginPath in allPath) {
                var plugins = GetPlugin(pluginPath);
                foreach (var plugin in plugins) {
                    var id = string.Format("{0}_{1}", plugin.PluginMeta.Name, plugin.PluginMeta.Id.ToString("N"));

                    if (PluginJob.PluginsList.ContainsKey(id)) {
                        if (PluginJob.PluginsList[id].PluginMeta.Version == plugin.PluginMeta.Version)
                            continue;
                        PluginJob.PluginsList[id] = plugin;
                        jobManager.UpdateJob(plugin);

                        Log.Warn(string.Format("[JobManager] Job {0} update to version {1}", plugin.PluginMeta.Name, plugin.PluginMeta.Version));
                    }
                    else {
                        PluginJob.PluginsList.Add(id, plugin);
                        jobManager.AddJob(plugin);

                        Log.Warn(string.Format("[JobManager] Job {0} version {1} added.", plugin.PluginMeta.Name, plugin.PluginMeta.Version));
                    }

                }
            }

            var jobs = scheduler
                .GetJobKeys(GroupMatcher<JobKey>
                .GroupEquals("PluginGroup"))
                .Where(u => !PluginJob.PluginsList
                    .ContainsKey(u.Name.ToString(CultureInfo.InvariantCulture)));
            foreach (var item in jobs) {
                var plugin = PluginJob.PluginsList[item.Name];
                jobManager.DeleteJob(plugin);
                Log.Warn(string.Format("[JobManager] Job {0} version {1} deleted.", PluginJob.PluginsList[item.Name], plugin.PluginMeta.Version));
                PluginJob.PluginsList.Remove(item.Name);
            }
        }

        private static IEnumerable<string> GetAllPluginPath(string folderPath)
        {
            var pluginsPath = Path.Combine(Environment.CurrentDirectory, folderPath);
            if (!Directory.Exists(pluginsPath)) {
                Directory.CreateDirectory(pluginsPath);
            }
            return Directory.EnumerateDirectories(pluginsPath);
        }

        private static PluginMeta GetPluginMeta(string pluginPath)
        {
            PluginMeta pluginMeta = null;
            var configPath = Path.Combine(pluginPath, ConfigName);
            if (!File.Exists(configPath)) {
                Log.Error(string.Format("Parse plugin config {0} failed: config file not found.", configPath));
                return null;
            }

            try {
                pluginMeta = JsonConvert.DeserializeObject<PluginMeta>(File.ReadAllText(configPath));
            }
            catch (Exception) {
                Log.Error(string.Format("Parse plugin config {0} failed: invalid config file.", configPath));
                return null;
            }

            if (!File.Exists(Path.Combine(pluginPath, pluginMeta.PluginFileName))) {
                Log.Error(string.Format("Parse plugin config {0} failed: plugin file {1} not found.", configPath,
                    pluginMeta.PluginFileName));
                return null;
            }

            pluginMeta.Directory = pluginPath;
            return pluginMeta;
        }

        private static IEnumerable<QzzzPlugin> GetPlugin(string pluginPath)
        {
            var pluginMeta = GetPluginMeta(pluginPath);
            if (pluginMeta == null)
                return new List<QzzzPlugin>();

            var dllPath = Path.Combine(pluginPath, pluginMeta.PluginFileName);
            return Assembly.LoadFrom(dllPath)
                .GetTypes()
                .Where(f => f.IsClass
                            && !f.IsAbstract
                            && f.GetInterface(typeof(IPlugin).ToString()) != null)
                .Select(Activator.CreateInstance)
                .OfType<IPlugin>().Select(p => new QzzzPlugin() {
                    Plugin = p,
                    PluginContext = InitContext(pluginPath),
                    PluginMeta = pluginMeta
                });
        }

        private static PluginContext InitContext(string pluginPath)
        {
            return new PluginContext() {
                LogInfo = Log.Info,
                GetLocation = s => Path.Combine(Environment.CurrentDirectory, PluginFolderName, pluginPath, s)
            };
        }
    }
}
