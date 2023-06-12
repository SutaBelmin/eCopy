using System;

namespace eCopy.Desktop
{
    public class PRDGridModel
    {
        public int ID { get; set; }
        public string Status { get; set; }
        public string Options { get; set; }
        public string Side { get; set; }
        public string Orientation { get; set; }
        public string Letter { get; set; }
        public string Pages { get; set; }
        public string Collate { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsPaid { get; set; }

        public string ClientName { get; set; }
        public string Price { get; set; }

    }
}
