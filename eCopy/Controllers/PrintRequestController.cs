using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using eCopy.Services;

namespace eCopy.Controllers
{
    public class PrintRequestController : BaseCRUDController<PrintRequestR, Request, PrintRequestSearch, eCopy.Model.Requests.PrintRequest, eCopy.Model.Requests.PrintRequestUpdate>
    {
        private readonly IPrintRequestService service;
        public PrintRequestController(IPrintRequestService service) : base(service)
        {
            this.service = service;
        }
    }
}
