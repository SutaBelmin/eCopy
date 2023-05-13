using eCopy.Model.Response;
using Microsoft.AspNetCore.Http;

namespace eCopy.Services
{
    public interface IFileService
    {
        UploadResponse Upload(byte[] file, string extension);
    }
}
