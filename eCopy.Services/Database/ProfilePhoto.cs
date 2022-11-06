using System;
using System.Collections.Generic;

namespace eCopy.Services
{
    public partial class ProfilePhoto
    {
        public ProfilePhoto()
        {
            ApplicationUserProfilePhotos = new HashSet<ApplicationUserProfilePhoto>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Active { get; set; }
        public string? Path { get; set; }
        public string? FileSystemPath { get; set; }
        public long SizeInBytes { get; set; }
        public string? Name { get; set; }
        public string? Extension { get; set; }
        public string? Format { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Xresolution { get; set; }
        public decimal Yresolution { get; set; }
        public string? ResolutionUnit { get; set; }

        public virtual ICollection<ApplicationUserProfilePhoto> ApplicationUserProfilePhotos { get; set; }
    }
}
