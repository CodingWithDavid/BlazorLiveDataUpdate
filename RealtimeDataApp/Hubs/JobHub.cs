using Microsoft.AspNetCore.SignalR;
using RealtimeDataApp.Data;

namespace RealtimeDataApp.Hubs
{
    public class JobHub : Hub
    {
        public async Task RefreshJob(List<Job> jobs)
        {

            await Clients.All.SendAsync("RefreshJobs", jobs);
        }
    }
}
