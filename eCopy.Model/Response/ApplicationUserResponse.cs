using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Model.Response
{
    public class ApplicationUserResponse
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool ChangePassword { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool Active { get; set; }
    }
}
