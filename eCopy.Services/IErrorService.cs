using eCopy.Model.Requests;

namespace eCopy.Services
{
    public interface IErrorService
    {
        void AddError(ErrorRequest request);
    }
}
