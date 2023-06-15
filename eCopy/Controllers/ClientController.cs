using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using eCopy.Services;
using Microsoft.AspNetCore.Authorization;

namespace eCopy.Controllers
{
    [Authorize]
    public class ClientController : BaseCRUDController<ClientResponse, Client, ClientSearch, ClientRequest, ClientRequestUpdate>
    {
        private readonly IClientService service;
        public ClientController(IClientService service) 
            : base(service)
        {
            this.service = service;
        }
    }
}
