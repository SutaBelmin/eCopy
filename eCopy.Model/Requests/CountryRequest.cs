
namespace eCopy.Model.Requests
{
    public class CountryRequest
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string PhoneNumberCode { get; set; }
        public string PhoneNumberRegex { get; set; }
        public bool Active { get; set; }
    }
}
