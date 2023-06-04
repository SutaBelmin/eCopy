using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database.Seed
{
    public static class RequestsSeed
    {
        public static void Seed(eCopyContext context)
        {
            if (!context.Requests.Any())
            {
                context.Requests.Add(new Request
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    Status = "Completed",
                    FilePath = "",
                    Options = "All",
                    Side = "PrintOneSided",
                    Orientation = "Portrait",
                    Letter = "A1",
                    Pages = "OnePage",
                    Collate = "Collated",
                    ClientId = 1,
                    CopierId = 1,
                    RequestDate = DateTime.Now,
                    Price = 50
                });

                context.Requests.Add(new Request
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    Status = "Completed",
                    FilePath = "",
                    Options = "All",
                    Side = "PrintBothSides",
                    Orientation = "Portrait",
                    Letter = "A6",
                    Pages = "OnePage",
                    Collate = "Uncollated",
                    ClientId = 1,
                    CopierId = 1,
                    RequestDate = DateTime.Now,
                    Price = 50
                });
            }
            context.SaveChanges();
        }

    }
}
