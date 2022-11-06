using eCopy.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Model.Response
{
    public class PrintRequestR
    {
        public string ID { get; set; }
        public Status Status { get; set; }
        public string FilePath { get; set; }
        public PrintPagesOptions Options { get; set; }
        public SidePrintOption Side { get; set; }
        public Orientation Orientation { get; set; }
        public Letter Letter { get; set; }
        public PagePerSheet Pages { get; set; }
        public CollatedPrintOptions Collate { get; set; }

        public int ClientId { get; set; }

        public ClientResponse Client { get; set; }
        public int CopierId { get; set; }

        public CopierResponse Copier { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
