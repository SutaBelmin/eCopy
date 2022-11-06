using AutoMapper;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services
{
    public class PrintRequestService : BaseCRUDService<PrintRequestR, Request, PrintRequestSearch, eCopy.Model.Requests.PrintRequest, eCopy.Model.Requests.PrintRequestUpdate>, IPrintRequestService
    {
        public PrintRequestService(eCopyContext context, IMapper mapper) : base(context, mapper)
        {

        }

       /* public override IEnumerable<PrintRequestR> Get(PrintRequestSearch search = null)
        {
            return base.Get(search);

            var entity = context.Requests.AsQueryable();

            var list = entity.Include(x => x.Status)
                             .Include(x => x.Options)
                             .Include(x => x.Side)
                             .Include(x => x.Orientation)
                             .Include(x => x.Letter)
                             .Include(x => x.Pages)
                             .Include(x => x.Collate).ToList();

            return mapper.Map<List<PrintRequestR>>(list);
                             
        }*/
    }
}
