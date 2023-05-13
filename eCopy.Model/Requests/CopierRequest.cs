using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Model.Requests
{
    public class CopierRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public TimeSpan? StartWorkingTime { get; set; }

        public TimeSpan? EndWorkingTime { get; set; }

        public string Url { get; set; }
        public string PhoneNumber { get; set; }

        public int? CityId { get; set; }

        public int CompanyId { get; set; }

        public bool Active { get; set; }
        public ApplicationUserRequest User { get; set; }
       // public ProfilePhoto ProfilePhoto { get; set; }
    }
}
