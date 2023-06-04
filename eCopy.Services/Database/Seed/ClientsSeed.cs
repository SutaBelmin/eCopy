using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database.Seed
{
    public static class ClientsSeed
    {
        public static void Seed(eCopyContext context)
        {
            if (!context.Clients.Any(x => x.Active == true))
            {
                context.Clients.Add(new Client
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    PersonId = 2,
                    ApplicationUserId = 1
                });
                context.SaveChanges();
            }
        }
    }
}
