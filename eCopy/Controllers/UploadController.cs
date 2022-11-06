using eCopy.Model.Options;
using Microsoft.AspNetCore.Mvc;
namespace eCopy.Controllers
{
    public class UploadController : Controller
    {
        private readonly ProfilePhotoOptions profilePhotoOptions;
        private readonly PrintRequestFileOptions printRequestFileOptions;

        public UploadController(ProfilePhotoOptions profilePhotoOptions, PrintRequestFileOptions printRequestFileOptions)
        {
            this.profilePhotoOptions = profilePhotoOptions;
            this.printRequestFileOptions = printRequestFileOptions;
        }
    }
}
