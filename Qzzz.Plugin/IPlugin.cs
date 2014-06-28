
namespace Qzzz.Plugin
{
    public interface IPlugin
    {
        /// <summary>
        /// Execute job
        /// </summary>
        void Execute(PluginContext pluginContext);

        /// <summary>
        /// return true to pause this job
        /// </summary>
        bool Pause(PluginContext pluginContext);
    }
}
