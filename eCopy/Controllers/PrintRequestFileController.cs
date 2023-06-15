using eCopy.Model.Response;
using eCopy.Services;
using Microsoft.AspNetCore.Authorization;

namespace eCopy.Controllers
{
    [Authorize]
    public class PrintRequestFileController : BaseCRUDController<PrintRequestFileR, PrintRequestFile, object, eCopy.Model.Requests.PrintRequestFile, eCopy.Model.Requests.PrintRequestFile>
    {
        private readonly IPrintRequestFileService service;
        public PrintRequestFileController(IPrintRequestFileService service) : base(service)
        {
            this.service = service;
        }
    }
}
