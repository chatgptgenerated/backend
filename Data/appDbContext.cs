using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using backend.Models;

namespace backend.Data {
    public class AppDbContext: DbContext {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration) {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Employee> Employees {get; set;}
    }
}