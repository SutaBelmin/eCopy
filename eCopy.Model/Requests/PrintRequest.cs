using eCopy.Model.Enum;
using Microsoft.AspNetCore.Http;

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
        public IFormFile File { get; set; }
        public double Price { get; set; }
        public string Comment { get; set; }
    }
}
