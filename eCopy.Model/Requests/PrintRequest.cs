using eCopy.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Model.Requests
{
    public class PrintRequest
    {
        public Status Status { get; set; }
        public PrintPagesOptions Options { get; set; }
        public SidePrintOption Side { get; set; }
        public Orientation Orientation { get; set; }
        public Letter Letter { get; set; }
        public PagePerSheet Pages { get; set; }
        public CollatedPrintOptions Collate { get; set; }
        public PrintRequestFile PrintRequestFile { get; set; }
        public byte[] File { get; set; }
        public double Price { get; set; }
    }
}
