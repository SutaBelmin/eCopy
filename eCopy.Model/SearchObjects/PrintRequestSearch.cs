using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Model.SearchObjects
{
    public class PrintRequestSearch
    {
        public string Status { get; set; }
        public string Options { get; set; }
        public string Side { get; set; }
        public string Orientation { get; set; }
        public string Letter { get; set; }
        public string Pages { get; set; }
        public string Collate { get; set; }

    }
}
