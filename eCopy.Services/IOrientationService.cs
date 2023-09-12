using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using System.Collections.Generic;

namespace eCopy.Services
{
    public interface IOrientationService : ICRUDService<OrientationResponse, OrientationSerach, eCopy.Model.Requests.OrientationRequest, eCopy.Model.Requests.OrientationRequestUpdate>
    {
        List<OrientationResponse> GetActive();
    }
}
