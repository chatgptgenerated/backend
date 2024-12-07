using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using backend.Models;

namespace backend.Data;
public class AppDbContext: IdentityDbContext<ApplicationUser> {

    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    public DbSet<Employee> Employees {get; set;}
    public DbSet<ApplicationUser> ApplicationUsers {get; set;}
}