using eCopy.Model.Response;

namespace eCopy.Services
{
    public interface IFileService
    {
        UploadResponse Upload(byte[] file, string extension);
    }
}
