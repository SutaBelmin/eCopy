﻿using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCopy.Services.Database
{
    public class IdentityUserRole : IdentityUserRole<int>
    {
        public bool Active { get; set; }

        public DateTime CreatedDate { get; set; }

        public IdentityUser User { get; set; }

        public IdentityRole Role { get; set; }
    }
}
