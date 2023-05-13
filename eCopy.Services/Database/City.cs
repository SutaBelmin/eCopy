using System;
using System.Collections.Generic;

namespace eCopy.Services
{
    public partial class City
    {
        public City()
        {
            Companies = new HashSet<Company>();
            Copiers = new HashSet<Copier>();
            People = new HashSet<Person>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Active { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public int PostalCode { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Copier> Copiers { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
