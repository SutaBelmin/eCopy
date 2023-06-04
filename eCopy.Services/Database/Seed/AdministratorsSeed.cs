using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database.Seed
{
    public static class AdministratorsSeed
    {
        public static void Seed(eCopyContext context)
        {
            if (!context.Administrators.Any(x => x.Active == true))
            {
                context.Administrators.Add(new Administrator
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Active = true,
                    ApplicationUserId = 3,
                    PersonId = 3,
                });
                context.SaveChanges();
            }
        }
    }
}
