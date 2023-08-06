using Microsoft.EntityFrameworkCore;

namespace RealtimeDataApp.Data
{
    public class AppDbContext : DbContext
    {
        string _connectionString = "Server=Davids-Beelink;Database=CompanyDatabase;Trusted_Connection=True;";

        public DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
