using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace eCopy.Services.Database
{
    public class IdentityRole : IdentityRole<int>
    {
        public ICollection<IdentityUserRole> AspNetUserRoles { get; set; }
    }
}
