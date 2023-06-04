using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database.Seed
{
    public static class ProfilePhotosSeed
    {
        public static void Seed(eCopyContext context)
        {
            if (!context.ProfilePhotos.Any(x => x.Active == true))
            {
                context.ProfilePhotos.Add(new ProfilePhoto
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null,
                    Active = true,
                    Path = "https://localhost:7284/bcb386f3-112c-44d9-8211-90c9172f5d82.png",
                    FileSystemPath = null,
                    SizeInBytes = 10413,
                    Name = "blank-profile-picture-973460_640",
                    Extension = ".png",
                    Format = null,
                    Height = decimal.Parse("0.00"),
                    Width = decimal.Parse("0.00"),
                    Xresolution = decimal.Parse("0.00"),
                    Yresolution = decimal.Parse("0.00"),
                    ResolutionUnit = null
                });
            }
        }
    }
}
