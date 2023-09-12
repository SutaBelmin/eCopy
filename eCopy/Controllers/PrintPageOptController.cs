using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using eCopy.Services.Database;
using eCopy.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace eCopy.Controllers
{
    [Authorize]
    public class PrintPageOptController : BaseCRUDController<PrintPageOptionResponse, PrintPageOption, PrintPageOptionSearch, PrintPageOptionRequest, PrintPageOptionRequestUpdate>
    {
        private readonly IPrintPageOptService service;

        public PrintPageOptController(IPrintPageOptService service) : base(service)
        {
            this.service = service;
        }

        [HttpGet("GetActive")]
        public List<PrintPageOptionResponse> GetActive()
        {
            return service.GetActive();
        }
    }
}
