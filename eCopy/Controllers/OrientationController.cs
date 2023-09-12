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
    public class OrientationController : BaseCRUDController<OrientationResponse, Orientation, OrientationSerach, OrientationRequest, OrientationRequestUpdate>
    {
        private readonly IOrientationService service;

        public OrientationController(IOrientationService service) : base(service)
        {
            this.service = service;
        }

        [HttpGet("GetActive")]
        public List<OrientationResponse> GetActive()
        {
            return service.GetActive();
        }
    }
}
