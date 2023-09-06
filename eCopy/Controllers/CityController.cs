using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using eCopy.Services;

namespace eCopy.Controllers
{
    public class CityController : BaseCRUDController<CityResponse, City, CitySearch, CityRequest, CityRequest>
    { 
        private readonly ICityService service;

        public CityController(ICityService service) : base(service)
        {
            this.service = service;
        }

    }
}
