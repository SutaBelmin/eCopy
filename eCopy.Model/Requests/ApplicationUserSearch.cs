using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Model.Requests
{
    public class ApplicationUserSearch
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public bool? Active { get; set; }

    }
}
