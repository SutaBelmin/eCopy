using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database.Seed
{
    public static class CountriesSeed
    {
        public static void Seed(eCopyContext context)
        {
            if (!context.Countries.Any(x => x.Name == "BosnaIHercegovina"))
            {
                context.Countries.Add(new Country
                {
                    Name = "BosnaIHercegovina",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    ShortName = "BiH",
                    PhoneNumberCode = "387",
                    PhoneNumberRegex = "asd"
                });
                context.SaveChanges();
            }
        }
    }
}
