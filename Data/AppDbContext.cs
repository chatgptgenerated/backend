using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using backend.Models;

namespace backend.Data;
public class AppDbContext: IdentityDbContext<ApplicationUser> {

    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    
    public DbSet<ApplicationUser> ApplicationUsers {get; set;}
    public DbSet<AidHelpee> AidHelpee { get; set; }

    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
        base.OnModelCreating(modelbuilder);

        modelbuilder.Entity<AidHelpee>()
            .HasKey(ab => new { ab.Id, ab.HelpingProfileId, ab.HelpedProfileId });
    }
}