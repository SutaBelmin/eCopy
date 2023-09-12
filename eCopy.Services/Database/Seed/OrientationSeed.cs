using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database.Seed
{
    public class OrientationSeed
    {
        public static void Seed(eCopyContext context)
        {
            if (!context.Orientation.Any())
            {
                context.Orientation.Add(new Orientation
                {
                    Name = "Portrait",
                    IsActive = true
                });
                context.Orientation.Add(new Orientation
                {
                    Name = "Landscape",
                    IsActive = true
                });
                context.SaveChanges();
            }
        }
    }
}
