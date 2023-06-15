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

            if(!context.Clients.Any())
            {
                context.Clients.Add(new Client
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    PersonId = 2,
                    ApplicationUserId = 1
                });
                context.Clients.Add(new Client
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    PersonId = 4,
                    ApplicationUserId = 4
                });
                context.Clients.Add(new Client
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    PersonId = 5,
                    ApplicationUserId = 5
                });
                context.Clients.Add(new Client
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    PersonId = 6,
                    ApplicationUserId = 6
                });
                context.Clients.Add(new Client
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    PersonId = 7,
                    ApplicationUserId = 7
                });
                context.Clients.Add(new Client
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    PersonId = 8,
                    ApplicationUserId = 8
                });
                context.SaveChanges();
            }
        }
    }
}
