
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
                    PrintPageOptionId = 1,
                    SidePrintOptionId = 1,
                    OrientationId = 1,
                    LetterId = 1,
                    PagePerSheetId = 1,
                    CollatedPrintOptionId = 1,
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
                    PrintPageOptionId = 1,
                    SidePrintOptionId = 1,
                    OrientationId = 2,
                    LetterId = 2,
                    PagePerSheetId = 1,
                    CollatedPrintOptionId = 2,
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
                    PrintPageOptionId = 1,
                    SidePrintOptionId = 1,
                    OrientationId = 1,
                    LetterId = 3,
                    PagePerSheetId = 1,
                    CollatedPrintOptionId = 1,
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
                    PrintPageOptionId = 1,
                    SidePrintOptionId = 1,
                    OrientationId = 2,
                    LetterId = 2,
                    PagePerSheetId = 1,
                    CollatedPrintOptionId = 2,
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
                    PrintPageOptionId = 1,
                    SidePrintOptionId = 1,
                    OrientationId = 1,
                    LetterId = 1,
                    PagePerSheetId = 1,
                    CollatedPrintOptionId = 1,
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
                    PrintPageOptionId = 1,
                    SidePrintOptionId = 1,
                    OrientationId = 2,
                    LetterId = 3,
                    PagePerSheetId = 1,
                    CollatedPrintOptionId = 2,
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
                    PrintPageOptionId = 1,
                    SidePrintOptionId = 1,
                    OrientationId = 1,
                    LetterId = 2,
                    PagePerSheetId = 1,
                    CollatedPrintOptionId = 1,
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
