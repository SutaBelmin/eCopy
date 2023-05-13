using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Model.Requests
{
    public class CityRequest
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int PostalCode { get; set; }
        public int CountryID { get; set; }
        public bool Active { get; set; }
    }
}
