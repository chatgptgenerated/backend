using backend.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (!context.Roles.Any()) {
                    context.Roles.AddRange(
                        new IdentityRole { Id = "admin_role_id", Name = "Admin", NormalizedName = "Admin".ToUpper() },
                        new IdentityRole { Id = "helper_role_id", Name = "Helper", NormalizedName = "Helper".ToUpper() },
                        new IdentityRole { Id = "helpee_role_id", Name = "Helpee", NormalizedName = "Helpee".ToUpper() }
                    );
                }

                if (!context.Users.Any())
                {

                    Guid ProfileToken = Guid.NewGuid();
                    String token1 = ProfileToken.ToString().Substring(0, 8);
                    ProfileToken = Guid.NewGuid();
                    String token2 = ProfileToken.ToString().Substring(0, 8);
                    ProfileToken = Guid.NewGuid();
                    String token3 = ProfileToken.ToString().Substring(0, 8);

                    var hasher = new PasswordHasher<ApplicationUser>();
                    context.Users.AddRange(
                        new ApplicationUser
                        {
                            // primary key
                            Id = "admin_acc_id",
                            UserName = "admin@test.com",
                            EmailConfirmed = true,
                            NormalizedEmail = "ADMIN@TEST.COM",
                            Email = "admin@test.com",
                            NormalizedUserName = "ADMIN@TEST.COM",
                            PasswordHash = hasher.HashPassword(null, "Admin1!"),
                            ProfileToken = token1,
                            PreferedLanguage = "en",
                            FirstName = "Admin",
                            LastName = "Adminescu"
                        },
                        new ApplicationUser
                        {
                            // primary key
                            Id = "helper_acc_id",
                            UserName = "helper@test.com",
                            EmailConfirmed = true,
                            NormalizedEmail = "HELPER@TEST.COM",
                            Email = "helper@test.com",
                            NormalizedUserName = "HELPER@TEST.COM",
                            PasswordHash = hasher.HashPassword(null, "Helper1!"),
                            FirstName = "Helper",
                            ProfileToken = token2,
                            PreferedLanguage = "en",
                            LastName = "Helperescu",
                        },
                        new ApplicationUser
                        {
                            // primary key
                            Id = "helpee_acc_id",
                            UserName = "helpee@test.com",
                            EmailConfirmed = true,
                            NormalizedEmail = "HELPEE@TEST.COM",
                            Email = "helpee@test.com",
                            NormalizedUserName = "HELPEE@TEST.COM",
                            PasswordHash = hasher.HashPassword(null, "Helpee1!"),
                            FirstName = "Helpee",
                            ProfileToken = token3,
                            PreferedLanguage = "en",
                            LastName = "Helpescu",
                        }
                    );
                }

                if (!context.UserRoles.Any())
                {
                    context.UserRoles.AddRange(
                        new IdentityUserRole<string>
                        {
                            RoleId = "admin_role_id",
                            UserId = "admin_acc_id"
                        },
                        new IdentityUserRole<string>
                        {
                            RoleId = "helper_role_id",
                            UserId = "helper_acc_id"
                        },
                        new IdentityUserRole<string>
                        {
                            RoleId = "helpee_role_id",
                            UserId = "helpee_acc_id"
                        }
                    );
                }

                if (!context.Notebooks.Any()) {
                    context.Notebooks.AddRange(
                        new Notebook
                        {
                            NotebookId = 1,
                            NotebookName = "Notebook 1"
                        },
                        new Notebook
                        {
                            NotebookId = 2,
                            NotebookName = "Notebook 2"
                        },
                        new Notebook
                        {
                            NotebookId = 3,
                            NotebookName = "Notebook 3"
                        }
                    );

                }

                if (!context.HelpeeNotebook.Any()){
                    context.HelpeeNotebook.AddRange(
                        new HelpeeNotebook
                        {
                            NotebookId = 1,
                            HelpeeId = "helpee_acc_id"
                        },
                        new HelpeeNotebook
                        {
                            NotebookId = 2,
                            HelpeeId = "helpee_acc_id"
                        },
                        new HelpeeNotebook
                        {
                            NotebookId = 3,
                            HelpeeId = "helpee_acc_id"
                        }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}
