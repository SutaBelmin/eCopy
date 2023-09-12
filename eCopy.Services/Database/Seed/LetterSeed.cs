using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database.Seed
{
    public class LetterSeed
    {
        public static void Seed(eCopyContext context)
        {
            if (!context.Letter.Any())
            {
                context.Letter.Add(new Letter
                {
                    Name = "A3",
                    IsActive = true,
                });
                context.Letter.Add(new Letter
                {
                    Name = "A4",
                    IsActive = true,
                });
                context.Letter.Add(new Letter
                {
                    Name = "A5",
                    IsActive = true,
                });
                context.SaveChanges();
            }
        }
    }
}
