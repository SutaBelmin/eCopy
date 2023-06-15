using eCopy.Services.Migrations;
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
                    Price = 50,
                    IsPaid = true
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
                    Price = 50,
                    IsPaid = false
                });

                context.Requests.Add(new Request
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    Status = "Completed",
                    FilePath = "",
                    Options = "All",
                    Side = "PrintOneSided",
                    Orientation = "Landscape",
                    Letter = "A4",
                    Pages = "OnePage",
                    Collate = "Uncollated",
                    ClientId = 2,
                    CopierId = 1,
                    RequestDate = DateTime.Now,
                    Price = 30,
                    IsPaid = false
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
                    Letter = "A3",
                    Pages = "OnePage",
                    Collate = "Collated",
                    ClientId = 3,
                    CopierId = 1,
                    RequestDate = DateTime.Now,
                    Price = 80,
                    IsPaid = false
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
                    Letter = "A4",
                    Pages = "OnePage",
                    Collate = "Uncollated",
                    ClientId = 4,
                    CopierId = 1,
                    RequestDate = DateTime.Now,
                    Price = 90,
                    IsPaid = false
                });

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
                    Letter = "A5",
                    Pages = "OnePage",
                    Collate = "Collated",
                    ClientId = 5,
                    CopierId = 1,
                    RequestDate = DateTime.Now.AddYears(-1),
                    Price = 45,
                    IsPaid = false
                });

                context.Requests.Add(new Request
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    Status = "Completed",
                    FilePath = "",
                    Options = "All",
                    Side = "PrintOneSided",
                    Orientation = "Landscape",
                    Letter = "A3",
                    Pages = "OnePage",
                    Collate = "Collated",
                    ClientId = 6,
                    CopierId = 1,
                    RequestDate = DateTime.Now.AddYears(-1),
                    Price = 10,
                    IsPaid = false
                });
            }
            context.SaveChanges();
        }

    }
}
