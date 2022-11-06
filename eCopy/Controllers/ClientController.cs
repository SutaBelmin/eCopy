using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using eCopy.Services;

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
    }
}
