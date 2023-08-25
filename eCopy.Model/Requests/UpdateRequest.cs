using eCopy.Model.Enum;

namespace eCopy.Model.Requests
{
    public class UpdateRequest
    {
        public Status Status { get; set; }
        public PrintPagesOptions Options { get; set; }
        public SidePrintOption Side { get; set; }
        public Orientation Orientation { get; set; }
        public Letter Letter { get; set; }
        public PagePerSheet Pages { get; set; }
        public CollatedPrintOptions Collate { get; set; }
    }
}
