using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Model.Response
{
    public class CountryReponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string PhoneNumberCode { get; set; }
        public string PhoneNumberRegex { get; set; }
        public bool Active { get; set; }
    }
}
