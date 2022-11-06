using System;
using System.Collections.Generic;

namespace eCopy.Services
{
    public partial class Copier
    {
        public Copier()
        {
            Employees = new HashSet<Employee>();
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Active { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public TimeSpan StartWorkingTime { get; set; }
        public TimeSpan EndWorkingTime { get; set; }
        public string? Url { get; set; }
        public string? PhoneNumber { get; set; }
        public int CityId { get; set; }
        public int CompanyId { get; set; }
        public int ApplicationUserId { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual Company Company { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
