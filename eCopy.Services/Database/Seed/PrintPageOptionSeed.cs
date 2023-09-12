using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database.Seed
{
    public class PrintPageOptionSeed
    {
        public static void Seed(eCopyContext context)
        {
            if (!context.PrintPageOption.Any())
            {
                context.PrintPageOption.Add(new PrintPageOption
                {
                    Name = "All",
                    IsActive = true,
                });
                context.PrintPageOption.Add(new PrintPageOption
                {
                    Name = "Even",
                    IsActive = true,
                });
                context.PrintPageOption.Add(new PrintPageOption
                {
                    Name = "Odd",
                    IsActive = true,
                });
                context.SaveChanges();
            }
        }
    }
}
