using eCopy.Model.Requests;

namespace eCopy.Services
{
    public interface IUserService : ICRUDService<Database.IdentityUser, object, ApplicationUserRequest, object>
    {
        Database.IdentityUser GetUserByUsername(string username);
    }
}
