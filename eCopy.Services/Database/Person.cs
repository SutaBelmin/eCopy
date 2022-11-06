using System;
using System.Collections.Generic;

namespace eCopy.Services
{
    public partial class Person
    {
        public Person()
        {
            Administrators = new HashSet<Administrator>();
            Clients = new HashSet<Client>();
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Active { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Gender { get; set; } = null!;
        public int CityId { get; set; }
        public string? Address { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual ICollection<Administrator> Administrators { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
