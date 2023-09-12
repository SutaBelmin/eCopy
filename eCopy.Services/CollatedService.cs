using AutoMapper;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using eCopy.Services.Database;
using System.Collections.Generic;
using System.Linq;

namespace eCopy.Services
{
    public class CollatedService : BaseCRUDService<CollatedResponse, CollatedPrintOption, CollatedSearch, CollatedRequest, CollatedRequestUpdate>, ICollatedService
    {
        public CollatedService(eCopyContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public List<CollatedResponse> GetActive()
        {
            var list = context.CollatedPrintOption.Where(x => x.IsActive == true).ToList();

            return mapper.Map<List<CollatedResponse>>(list);
        }
    }
}
