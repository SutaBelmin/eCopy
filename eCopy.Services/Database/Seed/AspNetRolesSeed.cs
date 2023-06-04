using System.Linq;

namespace eCopy.Services.Database.Seed
{
    public static class AspNetRolesSeed
    {
        public static void Seed(eCopyContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.Add(new Database.IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    ConcurrencyStamp = "9D2C0C77-41C3-49E8-B624-87A7089CCA20",
                });
                context.Roles.Add(new Database.IdentityRole
                {
                    Name = "Company",
                    NormalizedName = "Company",
                    ConcurrencyStamp = "9D2C0C77-41C3-49E8-B624-87A7089CCA20",
                });
                context.Roles.Add(new Database.IdentityRole
                {
                    Name = "Copier",
                    NormalizedName = "Copier",
                    ConcurrencyStamp = "9D2C0C77-41C3-49E8-B624-87A7089CCA20",
                });
                context.Roles.Add(new Database.IdentityRole
                {
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                    ConcurrencyStamp = "CACA37B2-C647-4786-928A-D296D92FF744",
                });
                context.Roles.Add(new Database.IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "79F1722C-274E-481D-A2A9-78DB1D3C3D2E",
                });
                context.SaveChanges();
            }
        }
    }
}
