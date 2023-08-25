using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;

namespace eCopy.Services
{
    public interface IClientService : ICRUDService<ClientResponse, ClientSearch, ClientRequest, ClientRequestUpdate>
    {
        ClientResponse GetByUsername(string username, string email);

        bool ChangePass(PassRequest request);

        ClientResponse GetClientAccount();

        ClientResponse MyUpdateClient(ClientRequestUpdate update);

    }
}
