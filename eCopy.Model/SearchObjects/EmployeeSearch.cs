using eCopy.Model.Enum;

namespace eCopy.Model.SearchObjects
{
    public class EmployeeSearch
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CopierId { get; set; }
        public int? CompanyId { get; set; }
        public Gender? Gender { get; set; }
        public bool? Active { get; set; }
    }
}
