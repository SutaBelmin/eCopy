using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Model.Response
{
    public class PersonResponse
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public int CityId { get; set; }
        public CityResponse City { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
