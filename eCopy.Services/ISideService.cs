using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using System.Collections.Generic;

namespace eCopy.Services
{
    public interface ISideService : ICRUDService<SideResponse, SideSearch, eCopy.Model.Requests.SideRequest, eCopy.Model.Requests.SideRequestUpdate>
    {
        List<SideResponse> GetActive();
    }
}
