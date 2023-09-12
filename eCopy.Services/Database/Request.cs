using eCopy.Services.Database;
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


        public int CollatedPrintOptionId { get; set; }
        public CollatedPrintOption CollatedPrintOption { get; set; }

        public int OrientationId { get; set; }
        public Orientation Orientation { get; set; }

        public int LetterId { get; set; }
        public Letter Letter { get; set; }

        public int PagePerSheetId { get; set; }
        public PagePerSheet PagePerSheet { get; set; }

        public int PrintPageOptionId { get; set; }
        public PrintPageOption PrintPageOption { get; set; }

        public int SidePrintOptionId { get; set; }
        public SidePrintOption SidePrintOption { get; set; }


        public int ClientId { get; set; }
        public int CopierId { get; set; }
        public DateTime RequestDate { get; set; }
        public double Price { get; set; }
        public bool IsPaid { get; set; }
        public string Comment { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Copier Copier { get; set; } = null!;
    }
}
