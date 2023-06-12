using eCopy.Model.Enum;
using System;

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
        public bool IsPaid { get; set; }
        public string ClientName { get; set; }
        public double Price { get; set; }
    }
}
