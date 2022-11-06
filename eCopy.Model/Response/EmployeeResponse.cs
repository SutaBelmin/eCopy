using eCopy.Model.Response;

namespace eCopy.Model
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public int PersonId { get; set; }
        public PersonResponse Person { get; set; }
        public int CopierId { get; set; }
        public CopierResponse Copier { get; set; }
        public ApplicationUserResponse User { get; set; }
        public string ProfilePhotoPath { get; set; }
    }
}
