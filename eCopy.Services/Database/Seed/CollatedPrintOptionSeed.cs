using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database.Seed
{
    public class CollatedPrintOptionSeed
    {
        public static void Seed(eCopyContext context)
        {
            if (!context.CollatedPrintOption.Any())
            {
                context.CollatedPrintOption.Add(new CollatedPrintOption
                {
                    Name = "Collated",
                    IsActive = true,
                });
                context.CollatedPrintOption.Add(new CollatedPrintOption
                {
                    Name = "Uncollated",
                    IsActive = true,
                });
                context.SaveChanges();
            }
        }
    }
}
