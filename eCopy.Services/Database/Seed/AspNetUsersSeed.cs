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
            if (!context.Users.Any(x => x.UserName == "mobile"))
            {
                context.Users.Add(new IdentityUser
                {
                    UserName = "mobile",
                    Active = false,
                    CreatedDate = DateTime.Now,
                    ChangePassword = false,
                    NormalizedUserName = "MOBILE",
                    Email = "mobile@hotmail.com",
                    NormalizedEmail = "MOBILE@HOTMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEDViG9MTpPn++4EbgR7CuZ2x3HUze5kZDELTnY7w7ntZK7PWNkqOk+1cENLfGBsLng==",
                    SecurityStamp = "074f4478-5665-44fc-9298-0bb22fec026d",
                    ConcurrencyStamp = "d6253cdd-776c-41de-a3e4-4d80109c591c",
                    PhoneNumber = "123321",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                });
            }
            if (!context.Users.Any(x => x.UserName == "employee"))
            {
                context.Users.Add(new IdentityUser
                {
                    UserName = "employee",
                    Active = false,
                    CreatedDate = DateTime.Now,
                    ChangePassword = false,
                    NormalizedUserName = "EMPLOYEE",
                    Email = "employee@hotmail.com",
                    NormalizedEmail = "EMP@HOTMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAENFWq1Fn368QIeIGakMvvHLODaOzAiGrkNkG6weEKn88rrl/4JuH6YhCy0q8R3rN0A==",
                    SecurityStamp = "707821bc-4667-4fc1-9ee3-677f83bc8acc",
                    ConcurrencyStamp = "7be355da-98d9-4a63-be3b-e550a433ac48",
                    PhoneNumber = "123321",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                });
            }
            if (!context.Users.Any(x => x.UserName == "admin"))
            {
                context.Users.Add(new IdentityUser
                {
                    UserName = "admin",
                    Active = false,
                    CreatedDate = DateTime.Now,
                    ChangePassword = false,
                    NormalizedUserName = "ADMIN",
                    Email = "admin@hotmail.com",
                    NormalizedEmail = "ADMIN@HOTMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEFyAiQ5TjKnf8uVQODSWq9h+do6j7LVIBaE/D5Ve5hhpjvkNkaosvNVf5Ftr9omdVw==",
                    SecurityStamp = "8a3206fc-36a4-4597-a067-45460c91a174",
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
