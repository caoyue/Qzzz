using System;

using Qzzz.Plugin;

namespace Qzzz.SimplePluginDemo
{
    public class SimplePlugin : IPlugin
    {
        public void Execute(PluginContext pluginContext)
        {
            pluginContext.LogInfo("Simple plugin executing now");
        }

        public bool Pause(PluginContext pluginContext)
        {
            return DateTime.Now > DateTime.Parse("2014-07-01");
        }
    }
}
