using eCopy.Model.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace eCopy.Services
{
    public class FileService : IFileService
    {
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;

        public FileService(Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            this.hostEnvironment = hostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
        }


        public UploadResponse Upload(byte[] file, string extension)
        {
            var fileName = $"{Guid.NewGuid()}{extension}";
            if (file.Length > 0)
            {
                var path = Path.Combine(hostEnvironment.WebRootPath, fileName);
                var memoryStream = new MemoryStream();
                memoryStream.Write(file, 0, file.Length);   

                using (var stream = System.IO.File.Create(path))
                {
                    memoryStream.Position = 0;
                    memoryStream.CopyTo(stream);
                }
            }
            var request = this.httpContextAccessor.HttpContext.Request;

            return new UploadResponse
            {
                Url = $"{request.Scheme}://{request.Host}{request.PathBase}/{fileName}"
            };
        }

    }
}
