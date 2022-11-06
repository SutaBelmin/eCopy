using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Model.SearchObjects
{
    public class CitySearch
    {
        public int? CountryID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int? PostalCode { get; set; }
        public bool? Active { get; set; }
    }
}
