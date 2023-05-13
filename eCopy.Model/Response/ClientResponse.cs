using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Model.Response
{
    public class ClientResponse
    {
        public int ID { get; set; }
        public ApplicationUserResponse ApplicationUser { get; set; }
        public PersonResponse Person { get; set; }
        public int PersonId { get; set; }
        public int ApplicationUserId { get; set; }
    }
}
