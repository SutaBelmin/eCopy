using eCopy.Model.Enum;
using System;

namespace eCopy.Desktop
{
    public class PrintReqModel
    {
        public int ID { get; set; }
        public Status Status { get; set; }
        public int CollatedPrintOptionId { get; set; }
        public int OrientationId { get; set; }
        public int LetterId { get; set; }
        public int PagePerSheetId { get; set; }
        public int PrintPageOptionId { get; set; }
        public int SidePrintOptionId { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsPaid { get; set; }
        public string ClientName { get; set; }
        public double Price { get; set; }
    }
}
