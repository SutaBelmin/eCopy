using eCopy.Model.Enum;

namespace eCopy.Model.Requests
{
    public class ApplicationUserRequest
    {
        public string Email { get; set; }
       
        public string Username { get; set; }
        
        public string PhoneNumber { get; set; }

        public Role Role { get; set; }

        public string Password { get; set; }
        
        public string PasswordConfirm { get; set; }
    }
}
