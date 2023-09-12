using AutoMapper;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using eCopy.Services.Database;
using System.Collections.Generic;
using System.Linq;

namespace eCopy.Services
{
    public class PagePerSheetService : BaseCRUDService<PagePerSheetResponse, PagePerSheet, PagePerSheetSearch, PagePerSheetRequest, PagePerSheetRequestUpdate>, IPagePerSheetService
    {
        public PagePerSheetService(eCopyContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public List<PagePerSheetResponse> GetActive()
        {
            var list = context.PagePerSheet.Where(x => x.IsActive == true).ToList();

            return mapper.Map<List<PagePerSheetResponse>>(list);
        }

    }
}
