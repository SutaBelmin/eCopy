using System;

namespace eCopy.Desktop
{
    public class PRDGridModel
    {
        public int ID { get; set; }
        public string Status { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsPaid { get; set; }
        public string ClientName { get; set; }
        public string Price { get; set; }

    }
}
