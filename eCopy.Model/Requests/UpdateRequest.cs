using eCopy.Model.Enum;

namespace eCopy.Model.Requests
{
    public class UpdateRequest
    {
        public Status Status { get; set; }
        public int CollatedPrintOptionId { get; set; }
        public int OrientationId { get; set; }
        public int LetterId { get; set; }
        public int PagePerSheetId { get; set; }
        public int PrintPageOptionId { get; set; }
        public int SidePrintOptionId { get; set; }
    }
}
