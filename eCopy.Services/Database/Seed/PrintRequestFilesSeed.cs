using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database.Seed
{
    public static class PrintRequestFilesSeed
    {
        public static void Seed(eCopyContext context)
        {
            if (!context.PrintRequestFiles.Any(x => x.Active == true))
            {
                context.PrintRequestFiles.Add(new PrintRequestFile
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Active = true,
                    Path = "https://10.0.2.2:7284/a25c64a8-b9e0-436b-a758-2258bf8e6431",
                    FileSystemPath = null,
                    SizeInBytes = 0,
                    Name = "File",
                    Extension = "",
                    RequestId = 1
                });
            }
        }
    }
}
