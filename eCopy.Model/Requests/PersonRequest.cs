using eCopy.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Model
{
    public class PersonRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Gender Gender { get; set; }
        public int? CityId { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
       
    }
}
