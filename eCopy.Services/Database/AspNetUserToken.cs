using Microsoft.AspNetCore.Identity;
using System;

namespace eCopy.Services
{
    public partial class IdentityUserToken : IdentityUserToken<int>
    {
        public bool? Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
