using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database.Seed
{
    public static class AspNetUserRolesSeed
    {
        public static void Seed(eCopyContext context)
        {
            if (!context.UserRoles.Any())
            {
                context.UserRoles.Add(new Database.IdentityUserRole
                {
                    UserId = 1,
                    RoleId = 5,
                    Active = true,
                    CreatedDate = DateTime.Now,
                });

                context.UserRoles.Add(new Database.IdentityUserRole
                {
                    UserId = 2,
                    RoleId = 4,
                    Active = true,
                    CreatedDate = DateTime.Now,
                });

                context.UserRoles.Add(new Database.IdentityUserRole
                {
                    UserId = 3,
                    RoleId = 1,
                    Active = true,
                    CreatedDate = DateTime.Now,
                });

                context.UserRoles.Add(new Database.IdentityUserRole
                {
                    UserId = 4,
                    RoleId = 5,
                    Active = true,
                    CreatedDate = DateTime.Now,
                });

                context.UserRoles.Add(new Database.IdentityUserRole
                {
                    UserId = 5,
                    RoleId = 5,
                    Active = true,
                    CreatedDate = DateTime.Now,
                });

                context.UserRoles.Add(new Database.IdentityUserRole
                {
                    UserId = 6,
                    RoleId = 5,
                    Active = true,
                    CreatedDate = DateTime.Now,
                });

                context.UserRoles.Add(new Database.IdentityUserRole
                {
                    UserId = 7,
                    RoleId = 5,
                    Active = true,
                    CreatedDate = DateTime.Now,
                });

                context.UserRoles.Add(new Database.IdentityUserRole
                {
                    UserId = 8,
                    RoleId = 5,
                    Active = true,
                    CreatedDate = DateTime.Now,
                });
                context.UserRoles.Add(new Database.IdentityUserRole
                {
                    UserId = 9,
                    RoleId = 4,
                    Active = true,
                    CreatedDate = DateTime.Now,
                });
                context.SaveChanges();
            }
        }
    }
}
