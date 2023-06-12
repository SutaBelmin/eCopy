
namespace eCopy.Model.Response
{
    public class CityResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int PostalCode { get; set; }
        public CountryResponse Country { get; set; }
        public int CountryID { get; set; }
        public bool Active { get; set; }
    }
}
