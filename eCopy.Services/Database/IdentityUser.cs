﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace eCopy.Services.Database
{
    public class IdentityUser : IdentityUser<int>
    {
        public IdentityUser()
        {
            SecurityStamp= Guid.NewGuid().ToString();
            ConcurrencyStamp = Guid.NewGuid().ToString();
        }

        public bool Active { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool ChangePassword { get; set; }

        public ICollection<Administrator> Administrators { get; set; }

        public ICollection<ApplicationUserProfilePhoto> ApplicationUserProfilePhotos { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public ICollection<IdentityUserRole> AspNetUserRoles { get; set; }
    }
}
