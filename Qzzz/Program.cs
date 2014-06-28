using Qzzz.Services;
using Topshelf;

namespace Qzzz
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(q => {
                q.SetDisplayName("QzzzService");
                q.SetServiceName("QzzzService");
                q.SetDescription("This is a Qzzz Service.");

                q.RunAsLocalSystem().StartAutomaticallyDelayed();

                q.Service<QzzzService>(s => {
                    s.ConstructUsing(name => new QzzzService());
                    s.WhenStarted((w, h) => w.Start(h));
                    s.WhenStopped((w, h) => w.Stop(h));
                });
            });
        }
    }
}
