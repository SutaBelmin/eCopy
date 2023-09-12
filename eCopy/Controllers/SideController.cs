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
    public class SideController : BaseCRUDController<SideResponse, SidePrintOption, SideSearch, SideRequest, SideRequestUpdate>
    {
        private readonly ISideService service;

        public SideController(ISideService service) : base(service)
        {
            this.service = service;
        }

        [HttpGet("GetActive")]
        public List<SideResponse> GetActive()
        {
            return service.GetActive();
        }

    }
}
