using Qzzz.Plugin;

namespace Qzzz.ToastPluginDemo
{
    public class ToastPlugin : IPlugin
    {
        public void Execute(PluginContext pluginContext)
        {
            pluginContext.LogInfo("Toast plugin executing now.");

            var toast = new Toast.Toast("Microsoft.Samples.DesktopToastsSample");
            toast.Show("Test", "Toast1", pluginContext.GetLocation("toast.png"));
            toast.Show("Test", "Toast2. Click Me!", pluginContext.GetLocation("Toast.png"),
                () => {
                    System.Diagnostics.Process.Start("http://2130706433");
                    pluginContext.LogInfo("Toast Activated!");
                },
                () => pluginContext.LogInfo("Toast Dismissed!")
            );
        }

        public bool Pause(PluginContext pluginContext)
        {
            return false;
        }
    }
}
