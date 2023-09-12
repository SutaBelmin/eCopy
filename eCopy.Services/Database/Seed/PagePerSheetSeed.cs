using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database.Seed
{
    public class PagePerSheetSeed
    {
        public static void Seed(eCopyContext context)
        {
            if (!context.PagePerSheet.Any())
            {
                context.PagePerSheet.Add(new PagePerSheet
                {
                    Name = "OnePage",
                    IsActive = true,
                });
                context.PagePerSheet.Add(new PagePerSheet
                {
                    Name = "TwoPages",
                    IsActive = true,
                });
                context.SaveChanges();
            }
        }
    }
}
