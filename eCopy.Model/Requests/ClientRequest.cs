using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Model.Requests
{
    public class ClientRequest
    {
        public bool Active { get; set; }
        public PersonRequest Person { get; set; }
        public ApplicationUserRequest User { get; set; }
    }
} 
