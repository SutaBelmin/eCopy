
namespace eCopy.Model.Requests
{
    public class ClientRequest
    {
        public bool Active { get; set; }
        public PersonRequest Person { get; set; }
        public ApplicationUserRequest User { get; set; }
    }
} 
