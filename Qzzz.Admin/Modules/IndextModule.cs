using Nancy;
using Newtonsoft.Json;

namespace Qzzz.Admin.Modules
{
    public class IndextModule : NancyModule
    {
        public IndextModule()
        {
            Get["/"] = _ => {
                var jobs = Scheduler.GetJobs();
                var response = (Response)JsonConvert.SerializeObject(jobs);
                response.ContentType = "application/json";
                return response;
            };

            Get["/Pause/{Group}/{Name}"] = p => {
                var job = new SchedulerJob(p.Name, p.Group);
                var response = (Response)JsonConvert.SerializeObject(job.Pause());
                response.ContentType = "application/json";
                return response;
            };

            Get["/Resume/{Group}/{Name}"] = p => {
                var job = new SchedulerJob(p.Name, p.Group);
                var response = (Response)JsonConvert.SerializeObject(job.Resume());
                response.ContentType = "application/json";
                return response;
            };

            Get["/Delete/{Group}/{Name}"] = p => {
                var job = new SchedulerJob(p.Name, p.Group);
                var response = (Response)JsonConvert.SerializeObject(job.Delete());
                response.ContentType = "application/json";
                return response;
            };
        }
    }
}

