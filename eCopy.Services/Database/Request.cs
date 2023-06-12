using System;
using System.Collections.Generic;

namespace eCopy.Services
{
    public partial class Request
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Active { get; set; }
        public string Status { get; set; } = null!;
        public string? FilePath { get; set; }
        public string Options { get; set; } = null!;
        public string Side { get; set; } = null!;
        public string Orientation { get; set; } = null!;
        public string Letter { get; set; } = null!;
        public string Pages { get; set; } = null!;
        public string Collate { get; set; } = null!;
        public int ClientId { get; set; }
        public int CopierId { get; set; }
        public DateTime RequestDate { get; set; }
        public double Price { get; set; }
        public bool IsPaid { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Copier Copier { get; set; } = null!;
    }
}
