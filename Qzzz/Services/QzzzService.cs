using Topshelf;

namespace Qzzz.Services
{
    public class QzzzService : ServiceControl
    {
        public bool Start(HostControl hostControl)
        {
            new SchedulerProvider().Show();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            new SchedulerProvider().Shutdown();
            return true;
        }
    }
}
