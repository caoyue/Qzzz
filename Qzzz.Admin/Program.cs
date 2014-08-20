using System;
using Nancy;
using Nancy.Hosting.Self;

namespace Qzzz.Admin
{
    class Program
    {
        static void Main(string[] args)
        {
            var hostConfigs = new HostConfiguration { UrlReservations = { CreateAutomatically = true } };
            using (var host = new NancyHost(hostConfigs, new Uri("http://localhost:1874"))) {
                host.Start();
                Console.ReadLine();
            }
        }
    }
}