using AutoMapper;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using eCopy.Services.Database;
using System.Collections.Generic;
using System.Linq;

namespace eCopy.Services
{
    public class SideService : BaseCRUDService<SideResponse, SidePrintOption, SideSearch, SideRequest, SideRequestUpdate>, ISideService
    {
        public SideService(eCopyContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public List<SideResponse> GetActive()
        {
            var list = context.SidePrintOption.Where(x => x.IsActive == true).ToList();

            return mapper.Map<List<SideResponse>>(list);
        }
    }
}
