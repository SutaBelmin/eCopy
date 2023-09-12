using eCopy.Model.Enum;
using System;

namespace eCopy.Model.Response
{
    public class PrintRequestR
    {
        public string ID { get; set; }
        public Status Status { get; set; }
        public string FilePath { get; set; }
        public PrintPageOptionResponse PrintPageOption { get; set; }
        public int PrintPageOptionId { get; set; }

        public SideResponse SidePrintOption { get; set; }
        public int SidePrintOptionId { get; set; }

        public OrientationResponse Orientation { get; set; }
        public int OrientationId { get; set; }

        public LetterResponse Letter { get; set; }
        public int LetterId { get; set; }

        public PagePerSheetResponse PagePerSheet { get; set; }
        public int PagePerSheetId { get; set; }

        public CollatedResponse CollatedPrintOption { get; set; }
        public int CollatedPrintOptionId { get; set; }

        public double Price { get; set; }
        public string Comment { get; set; }

        public int ClientId { get; set; }

        public ClientResponse Client { get; set; }
        public int CopierId { get; set; }

        public CopierResponse Copier { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsPaid { get; set; }
        public string ClientName { get; set; }


        public int PaymentId { get; set; }
        public PaymentResponse PaymentInfo { get; set; }
    }
}
