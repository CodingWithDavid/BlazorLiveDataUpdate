using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using RealtimeDataApp.Hubs;
using TableDependency.SqlClient.Base.EventArgs;
using TableDependency.SqlClient;
using RealtimeDataApp.Data;

namespace RealtimeDataApp.Services
{
    public class JobsService
    {
        private readonly IHubContext<JobHub> _context;
        AppDbContext dbContext = new AppDbContext();
        private readonly SqlTableDependency<Job> _dependency;
        private readonly string _connectionString;

        public JobsService(IHubContext<JobHub> context)
        {
            _context = context;
            _connectionString = "Server=Davids-Beelink;Database=CompanyDatabase;Trusted_Connection=True;";
            _dependency = new SqlTableDependency<Job>(_connectionString, "Jobs");
            _dependency.OnChanged += Changed;
            _dependency.Start();
        }

        private async void Changed(object sender, RecordChangedEventArgs<Job> e)
        {
            var employees = await GetAllJobs();
            await _context.Clients.All.SendAsync("RefreshJobs", employees);
        }

        public async Task<List<Job>> GetAllJobs()
        {
            return await dbContext.Jobs.AsNoTracking().ToListAsync();
        }
    }

}
