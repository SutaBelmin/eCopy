
namespace eCopy.Model.Requests
{
    public class ErrorRequest
    {
        public string Message { get; set; }
        public string Url { get; set; }
        public string Method { get; set; }
        public int? KorisnickiNalogId { get; set; }
    }
}
