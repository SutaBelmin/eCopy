namespace eCopy.Model.Requests
{
    public class EmployeeRequest
    {
        public PersonRequest Person { get; set; }
        public int? CopierId { get; set; }
        public bool Active { get; set; }
        public ApplicationUserRequest User { get; set; }
        public byte[] ProfilePhoto { get; set; }
        public string ProfilePhotoName { get; set; }
        public string ProfilePhotoExtension { get; set; }
    }
}
