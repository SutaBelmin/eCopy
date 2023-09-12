using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using System.Collections.Generic;

namespace eCopy.Services
{
    public interface ICollatedService : ICRUDService<CollatedResponse, CollatedSearch, eCopy.Model.Requests.CollatedRequest, eCopy.Model.Requests.CollatedRequestUpdate>
    {
        List<CollatedResponse> GetActive();
    }
}
