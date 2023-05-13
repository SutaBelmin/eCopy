using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services
{
    public interface IClientService : ICRUDService<ClientResponse, ClientSearch, ClientRequest, ClientRequestUpdate>
    {

    }
}
