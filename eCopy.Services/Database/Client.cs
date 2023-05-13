using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace eCopy.Services
{
    public partial class Client
    {
        public Client()
        {
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Active { get; set; }
        public int PersonId { get; set; } 
        public virtual Person Person { get; set; } = null!;
        public int ApplicationUserId { get; set; }
        public virtual Database.IdentityUser ApplicationUser { get; set; } = null!;

        public virtual ICollection<Request> Requests { get; set; }
    }
}
