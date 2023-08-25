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
        public ClientResponse GetByUsername(string username, string email)
        {
            return service.GetByUsername(username, email);
        }


        [HttpPut("ChangePass")]
        public bool ChangePass(PassRequest request)
        {
            return service.ChangePass(request);
        }

        [HttpGet("GetClientAccount")]
        public ClientResponse GetClientAccount()
        {
            return service.GetClientAccount();
        }

        [HttpPut("MyUpdateClient")]
        public ClientResponse MyUpdateClient(ClientRequestUpdate update)
        {
            return service.MyUpdateClient(update);
        }
    }
}
