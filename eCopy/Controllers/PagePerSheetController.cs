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
    public class PagePerSheetController : BaseCRUDController<PagePerSheetResponse, PagePerSheet, PagePerSheetSearch, PagePerSheetRequest, PagePerSheetRequestUpdate>
    {
        private readonly IPagePerSheetService service;

        public PagePerSheetController(IPagePerSheetService service) : base(service)
        {
            this.service = service;
        }

        [HttpGet("GetActive")]
        public List<PagePerSheetResponse> GetActive()
        {
            return service.GetActive();
        }
    }
}
