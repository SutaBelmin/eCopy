using System;

namespace eCopy.Model.Requests
{
    public class PrintRequestFile
    {
        public bool Active { get; set; }
        public int ApplicationUserId { get; set; }
        public string Path { get; set; }
        public string FileSystemPath { get; set; }
        public Int64 SizeInBytes { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
    }
}
