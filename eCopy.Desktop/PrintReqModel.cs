using eCopy.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Desktop
{
    public class PrintReqModel
    {
        public int ID { get; set; }
        public Status Status { get; set; }
        public PrintPagesOptions Options { get; set; }
        public SidePrintOption Side { get; set; }
        public Model.Enum.Orientation Orientation { get; set; }
        public Letter Letter { get; set; }
        public PagePerSheet Pages { get; set; }
        public CollatedPrintOptions Collate { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
