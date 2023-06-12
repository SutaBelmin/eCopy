using eCopy.Model.Requests;
using eCopy.Model.Response;

namespace eCopy.Services
{
    public interface IAuthenticationService
    {
        AuthenticationResponse Authenticate(AuthenticationRequest request);
    }
}
