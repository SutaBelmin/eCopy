using System;
using System.Collections.Generic;

namespace eCopy.Services
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Active { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public string? PhoneNumberCode { get; set; }
        public string? PhoneNumberRegex { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
