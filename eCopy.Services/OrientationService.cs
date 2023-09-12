using AutoMapper;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using eCopy.Services.Database;
using System.Collections.Generic;
using System.Linq;

namespace eCopy.Services
{
    public class OrientationService : BaseCRUDService<OrientationResponse, Orientation, OrientationSerach, OrientationRequest, OrientationRequestUpdate>, IOrientationService
    {
        public OrientationService(eCopyContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public List<OrientationResponse> GetActive()
        {
            var list = context.Orientation.Where(x => x.IsActive == true).ToList();

            return mapper.Map<List<OrientationResponse>>(list);
        }
    }
}
