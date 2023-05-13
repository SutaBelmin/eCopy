using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace eCopy.Services
{
    public partial class ApplicationUserProfilePhoto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Active { get; set; }
        public int ApplicationUserId { get; set; }
        public int ProfilePhotoId { get; set; }

        public virtual Database.IdentityUser ApplicationUser { get; set; } = null!;
        public virtual ProfilePhoto ProfilePhoto { get; set; } = null!;
    }
}
