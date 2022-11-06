using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database
{
    public class Error
    {
        public int Id { get; set; }
        public int AspNetUserId { get; set; }
        public Database.IdentityUser AspNetUser { get; set; }
        public string Message { get; set; }
        public string Method { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
        
    }
}
