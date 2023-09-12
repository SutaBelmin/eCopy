using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;

namespace eCopy.Services
{
    public interface ICityService : ICRUDService<CityResponse, CitySearch, CityRequest, CityRequest>
    {
        CityEResponse CityExist(string name, int postalCode);
    }
}
