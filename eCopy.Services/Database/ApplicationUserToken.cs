using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace eCopy.Services
{
    public partial class ApplicationUserToken
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Active { get; set; }
        public int UserId { get; set; }
        public string TokenType { get; set; } = null!;
        public string? Value { get; set; }

        public virtual Database.IdentityUser User { get; set; } = null!;
    }
}
