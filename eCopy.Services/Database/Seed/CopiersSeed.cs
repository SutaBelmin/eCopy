using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database.Seed
{
    public static class CopiersSeed
    {
        public static void Seed(eCopyContext context)
        {
            if (!context.Copiers.Any(x => x.Name == "copier"))
            {
                context.Copiers.Add(new Copier
                {
                    Name = "copier",
                    CreatedDate= DateTime.Now,
                    ModifiedDate=null,
                    Active=true,
                    Description="description",
                    StartWorkingTime =  TimeSpan.FromHours(8),
                    EndWorkingTime = TimeSpan.FromHours(11),
                    Url = "nekiurl.com",
                    PhoneNumber = "123123",
                    CityId = 1,
                    CompanyId = 1,
                    ApplicationUserId = 1
                });
                context.SaveChanges();
            }
        }
    }
}
