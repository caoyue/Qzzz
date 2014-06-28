using System;
using System.Runtime;

namespace Qzzz.Plugin
{
    public class PluginMeta
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }

        public string Description { get; set; }

        public string CronExpression { get; set; }

        public DateTime? StartAt { get; set; }

        public DateTime? EndAt { get; set; }

        public string PluginFileName { get; set; }

        public string Author { get; set; }

        public string Url { get; set; }

        public string Directory { get; set; }
    }
}
