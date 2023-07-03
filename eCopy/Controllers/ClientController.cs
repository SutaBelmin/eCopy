using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using eCopy.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCopy.Controllers
{
    public class ClientController : BaseCRUDController<ClientResponse, Client, ClientSearch, ClientRequest, ClientRequestUpdate>
    {
        private readonly IClientService service;
        public ClientController(IClientService service) 
            : base(service)
        {
            this.service = service;
        }

        [HttpGet("GetByUsername")]
        [AllowAnonymous]
        public ClientResponse GetByUsername(string username)
        {
            return service.GetByUsername(username);
        }
    }
}
