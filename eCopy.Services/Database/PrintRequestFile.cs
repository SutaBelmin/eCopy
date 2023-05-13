using System;
using System.Collections.Generic;

namespace eCopy.Services
{
    public partial class PrintRequestFile
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Active { get; set; }
        public string? Path { get; set; }
        public string? FileSystemPath { get; set; }
        public long SizeInBytes { get; set; }
        public string? Name { get; set; }
        public string? Extension { get; set; }

        public int RequestId { get; set; }
        public Request Request { get; set; }
    }
}
