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
            if (!context.Users.Any(x => x.UserName == "cliuser"))
            {
                context.Users.Add(new IdentityUser
                {
                    UserName = "cliuser",
                    Active = false,
                    CreatedDate = DateTime.Now,
                    ChangePassword = false,
                    NormalizedUserName = "CLIUSER",
                    Email = "cliuser@hotmail.com",
                    NormalizedEmail = "CLIUSER@HOTMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEPAZEzgvqHrYA7bCPLHzLTJmHuai6aRLIFNW+8znB4P0z8UxMpgw/+NnBis4QWZeEg==",
                    SecurityStamp = "def5c8b2-1388-4ff8-ae8a-28904546f4ca",
                    ConcurrencyStamp = "23dcc790-b56c-4c1f-ad62-b9a8e0c848ab",
                    PhoneNumber = "123321",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                });
            }
            if (!context.Users.Any(x => x.UserName == "cliuser2"))
            {
                context.Users.Add(new IdentityUser
                {
                    UserName = "cliuser2",
                    Active = false,
                    CreatedDate = DateTime.Now,
                    ChangePassword = false,
                    NormalizedUserName = "CLIUSER2",
                    Email = "cliuser2@hotmail.com",
                    NormalizedEmail = "CLIUSER2@HOTMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEGzeXL6UYZkPATZxNyJD5zasZuKsw8kq3N8de3ISbqIx54bbfTPulHFQ5LYJBbUXhw==",
                    SecurityStamp = "3263fbaa-589e-49cd-9f64-41d32e36a031",
                    ConcurrencyStamp = "e1eb123e-0596-4ec0-aa4c-14c2fd68a0d9",
                    PhoneNumber = "123321",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                });
            }
            if (!context.Users.Any(x => x.UserName == "cliuser3"))
            {
                context.Users.Add(new IdentityUser
                {
                    UserName = "cliuser3",
                    Active = false,
                    CreatedDate = DateTime.Now,
                    ChangePassword = false,
                    NormalizedUserName = "CLIUSER3",
                    Email = "cliuser3@hotmail.com",
                    NormalizedEmail = "CLIUSER3@HOTMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEIYEmQWXyAG8oLjQGb3Cc6+ISgcCWn4+D1nkOcTXEa1gJkK/klxnwFe8QC9fRKFRgw==",
                    SecurityStamp = "a371f551-239c-49c8-9071-5e2fcaaeb97a",
                    ConcurrencyStamp = "5d6d38d7-1bd8-422e-80d7-8575e16be94a",
                    PhoneNumber = "123321",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                });
            }
            if (!context.Users.Any(x => x.UserName == "cliuser4"))
            {
                context.Users.Add(new IdentityUser
                {
                    UserName = "cliuser4",
                    Active = false,
                    CreatedDate = DateTime.Now,
                    ChangePassword = false,
                    NormalizedUserName = "CLIUSER4",
                    Email = "cliuser4@hotmail.com",
                    NormalizedEmail = "CLIUSER4@HOTMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEO+ah9J8DXgv0k1cTZ+aD4tQ/+WMuyUWNvB7J0trG8FLQf4uDFuPrSAwYFwgydji9Q==",
                    SecurityStamp = "8ff43133-fac2-4780-aac4-970690bb1c22",
                    ConcurrencyStamp = "a5f47d05-8c4b-491a-8fb8-d9cc2f9d6631",
                    PhoneNumber = "123321",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                });
            }
            if (!context.Users.Any(x => x.UserName == "cliuser5"))
            {
                context.Users.Add(new IdentityUser
                {
                    UserName = "cliuser5",
                    Active = false,
                    CreatedDate = DateTime.Now,
                    ChangePassword = false,
                    NormalizedUserName = "CLIUSER5",
                    Email = "cliuser5@hotmail.com",
                    NormalizedEmail = "CLIUSER5@HOTMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEKnpc7R6PeDF/9C6u9bOLTUGW+Y7mHzX0zbGiqLuPcvpJPBo0NP6WkCwvmykIubhDQ==",
                    SecurityStamp = "f84b1632-432f-416f-8b27-ab493e04cb60",
                    ConcurrencyStamp = "2167c985-a24b-4628-8157-869f0201a469",
                    PhoneNumber = "123321",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                });
            }
            if (!context.Users.Any(x => x.UserName == "emp2"))
            {
                context.Users.Add(new IdentityUser
                {
                    UserName = "emp2",
                    Active = false,
                    CreatedDate = DateTime.Now,
                    ChangePassword = false,
                    NormalizedUserName = "EMP2",
                    Email = "emp2@hotmail.com",
                    NormalizedEmail = "EMP2@HOTMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAECZyaV66fzVCxvRMng0MECYfqkvK8vh2XWwaWWJRHjjZ8SQe63Oh8VmCl0rnKB5yMw==",
                    SecurityStamp = "5f5274d5-2c2e-4bc1-98ea-854cbe623289",
                    ConcurrencyStamp = "47c3ec2d-5a7f-4455-82b8-14e569610681",
                    PhoneNumber = "123321",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                });
            }
            context.SaveChanges();

        }
    }
}
