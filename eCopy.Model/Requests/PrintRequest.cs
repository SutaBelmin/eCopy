using eCopy.Model.Enum;
using Microsoft.AspNetCore.Http;

namespace eCopy.Model.Requests
{
    public class PrintRequest
    {
        public Status Status { get; set; }

        public int CollatedPrintOptionId { get; set; }
        public int OrientationId { get; set; }
        public int LetterId { get; set; }
        public int PagePerSheetId { get; set; }
        public int PrintPageOptionId { get; set; }
        public int SidePrintOptionId { get; set; }
       
        public PrintRequestFile PrintRequestFile { get; set; }
        public IFormFile File { get; set; }
        public double Price { get; set; }
        public string Comment { get; set; }
    }
}
