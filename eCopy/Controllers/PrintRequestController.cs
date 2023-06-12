using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using eCopy.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCopy.Controllers
{
    [Authorize]
    public class PrintRequestController : BaseCRUDController<PrintRequestR, Request, PrintRequestSearch, eCopy.Model.Requests.PrintRequest, eCopy.Model.Requests.PrintRequestUpdate>
    {
        private readonly IPrintRequestService service;

        public PrintRequestController(IPrintRequestService service) : base(service)
        {
            this.service = service;
        }

        [HttpPost]
        public override PrintRequestR Insert([FromForm] eCopy.Model.Requests.PrintRequest model)
        {
            return base.Insert(model);
        }

        [HttpPost("pay/{id}")]
        public PrintRequestR Pay(int id)
        {
            return service.Pay(id);
        }
    }
}
