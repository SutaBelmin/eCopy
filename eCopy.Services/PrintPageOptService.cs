using AutoMapper;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using eCopy.Services.Database;
using System.Collections.Generic;
using System.Linq;

namespace eCopy.Services
{
    public class PrintPageOptService : BaseCRUDService<PrintPageOptionResponse, PrintPageOption, PrintPageOptionSearch, PrintPageOptionRequest, PrintPageOptionRequestUpdate>, IPrintPageOptService
    {
        public PrintPageOptService(eCopyContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public List<PrintPageOptionResponse> GetActive()
        {
            var list = context.PrintPageOption.Where(x => x.IsActive == true).ToList();

            return mapper.Map<List<PrintPageOptionResponse>>(list);
        }
    }
}
