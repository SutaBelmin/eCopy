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
    public class LetterController : BaseCRUDController<LetterResponse, Letter, LetterSearch, LetterRequest, LetterRequestUpdate>
    {
        private readonly ILetterService service;

        public LetterController(ILetterService service) : base(service)
        {
            this.service = service;
        }

        [HttpGet("GetActive")]
        public List<LetterResponse> GetActive()
        {
           return service.GetActive();
        }

    }
}
