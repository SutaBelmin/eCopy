using Microsoft.AspNetCore.Identity;
using System;

namespace eCopy.Services.Database
{
    public class IdentityUserClaim : IdentityUserClaim<int>
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Active { get; set; }
    }
}
