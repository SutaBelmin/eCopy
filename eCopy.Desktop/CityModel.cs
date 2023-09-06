using eCopy.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Desktop
{
    public class CityModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int PostalCode { get; set; }

        //public CountryResponse Country { get; set; }
        //public int CountryID { get; set; }
        //public bool Active { get; set; }
    }
}
