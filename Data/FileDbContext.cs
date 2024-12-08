using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using backend.Models;

namespace backend.Data;
public class FileDbContext : DbContext {

    public FileDbContext(DbContextOptions<FileDbContext> options)
            : base(options)
        {
        }
    
    public DbSet<FileModel> FileModels {get; set;}
    // public DbSet<AidHelpee> AidHelpee { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelbuilder)
    // {
    //     base.OnModelCreating(modelbuilder);

    //     modelbuilder.Entity<AidHelpee>()
    //         .HasKey(ab => new { ab.Id, ab.HelpingProfileId, ab.HelpedProfileId });
    // }
}