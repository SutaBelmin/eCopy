using System;
using eCopy.Model.Enum;

namespace eCopy.Model.Requests
{
    public class ClientRequestUpdate
    {
        public bool? Active { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Gender Gender { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }

    }
}
