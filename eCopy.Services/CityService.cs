using AutoMapper;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services
{
    public class CityService : BaseCRUDService<CityResponse, City, CitySearch, CityRequest, CityRequest>, ICityService
    {
        public CityService(eCopyContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
