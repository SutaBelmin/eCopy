using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using eCopy.Services;
using eCopy.Services.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eCopy.Controllers
{
    [Authorize]
    public class CollatedController : BaseCRUDController<CollatedResponse, CollatedPrintOption, CollatedSearch, CollatedRequest, CollatedRequestUpdate>
    {
        private readonly ICollatedService service;

        public CollatedController(ICollatedService service) : base(service)
        {
            this.service = service;
        }

        [HttpGet("GetActive")]
        public List<CollatedResponse> GetActive()
        {
            return service.GetActive();
        }
    }
}
