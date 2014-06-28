using System;
using System.Collections.Generic;

namespace Qzzz.Plugin
{
    public class PluginContext
    {
        public PluginContext()
        {
        }

        /// <summary>
        ///
        /// </summary>
        public Dictionary<string, object> DataMap { get; set; }

        /// <summary>
        /// Add log
        /// </summary>
        public Action<string> LogInfo { get; set; }

        /// <summary>
        /// Get file location in plugin folder
        /// </summary>
        public Func<string, string> GetLocation { get; set; }
    }
}
