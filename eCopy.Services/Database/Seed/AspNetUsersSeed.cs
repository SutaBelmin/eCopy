using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database.Seed
{
    public static class AspNetUsersSeed
    {
        public static void Seed(eCopyContext context)
        {
            if (!context.Users.Any(x => x.UserName == "client"))
            {
                context.Users.Add(new IdentityUser
                {
                    UserName = "client",
                    Active = false,
                    CreatedDate = DateTime.Now,
                    ChangePassword = false,
                    NormalizedUserName = "CLIENT",
                    Email = "client@hotmail.com",
                    NormalizedEmail = "CLIENT@HOTMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAED9ivvrENebu0rTr4rxcNH/bcOPa6QvstBM7euQbklr9ggWX8VjzEJQdDPBDtzRZWg==",
                    SecurityStamp = "9C697B15-CBB3-4FD5-9C4A-C6384992A90C",
                    ConcurrencyStamp = "d6253cdd-776c-41de-a3e4-4d80109c591c",
                    PhoneNumber = "123321",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                });
            }
            if (!context.Users.Any(x => x.UserName == "emp"))
            {
                context.Users.Add(new IdentityUser
                {
                    UserName = "emp",
                    Active = false,
                    CreatedDate = DateTime.Now,
                    ChangePassword = false,
                    NormalizedUserName = "EMP",
                    Email = "emp@hotmail.com",
                    NormalizedEmail = "EMP@HOTMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEBhPl925AtAnFbvFfDkRfw5sZXvt92WSmggDH+kb/CMSAwr1pmLzcSkwAJ0tBcpuUg==",
                    SecurityStamp = "5BE5BF74-3D0C-4773-BB0B-90AE4B82CEFA",
                    ConcurrencyStamp = "7be355da-98d9-4a63-be3b-e550a433ac48",
                    PhoneNumber = "123321",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                });
            }
            if (!context.Users.Any(x => x.UserName == "cc"))
            {
                context.Users.Add(new IdentityUser
                {
                    UserName = "cc",
                    Active = false,
                    CreatedDate = DateTime.Now,
                    ChangePassword = false,
                    NormalizedUserName = "CC",
                    Email = "cc@hotmail.com",
                    NormalizedEmail = "CC@HOTMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEEAxziNvt168Bce8kzNwoV7iSAMSyUAfv05PqtXltij6wsPZEUHwZf3gZrmbIEZc6A==",
                    SecurityStamp = "2a9cc242-94ad-4098-a27f-976765f2583a",
                    ConcurrencyStamp = "569e499c-9f91-4957-b331-e4b818ea3c65",
                    PhoneNumber = "123321",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                });
            }
            context.SaveChanges();

        }
    }
}
