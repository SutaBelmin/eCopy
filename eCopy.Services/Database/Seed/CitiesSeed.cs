using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database.Seed
{
    public static class CitiesSeed
    {
        public static void Seed(eCopyContext context)
        {
            if (!context.Cities.Any(x => x.Name == "Sarajevo"))
            {
                context.Cities.Add(new City
                {
                    Name = "Sarajevo",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    ShortName = "Sa",
                    PostalCode = 71000,
                    CountryId = 1
                });
                
            }
            if (!context.Cities.Any(x => x.Name == "Mostar"))
            {
                context.Cities.Add(new City
                {
                    Name = "Mostar",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    ShortName = "Mo",
                    PostalCode = 88300,
                    CountryId = 1
                });
            }
            context.SaveChanges();
        }
    }
}
