using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.WinUI
{
    public class EmployeeDetailsModel
    {
        public bool Active { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string CopierName { get; set; }
        public byte[] ProfilePhoto { get; set; }
    }
}
