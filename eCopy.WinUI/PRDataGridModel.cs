using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.WinUI
{
    public class PRDataGridModel
    {
        public int ID { get; set; }
        public string Status { get; set; }
        public string Options { get; set; }
        public string Side { get; set; }
        public string Orientation { get; set; }
        public string Letter { get; set; }
        public string Pages { get; set; }
        public string Collate { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
