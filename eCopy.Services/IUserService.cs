using eCopy.Model.Requests;
using eCopy.Model.Response;

namespace eCopy.Services
{
    public interface IUserService : ICRUDService<Database.IdentityUser, object, ApplicationUserRequest, object>
    {
        Database.IdentityUser GetUserByUsername(string username);

        GetByUsernameOrEmail GetByUsrnameOrEmail(string username, string email);
    }
}
