using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database.Seed
{
    public class SidePrintOptionSeed
    {
        public static void Seed(eCopyContext context)
        {
            if (!context.SidePrintOption.Any())
            {
                context.SidePrintOption.Add(new SidePrintOption
                {
                    Name = "PrintOneSided",
                    IsActive = true,
                });
                context.SidePrintOption.Add(new SidePrintOption
                {
                    Name = "PrintBothSides",
                    IsActive = true,
                });
                context.SaveChanges();
            }
        }
    }
}
