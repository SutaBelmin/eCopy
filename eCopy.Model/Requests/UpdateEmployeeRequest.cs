using eCopy.Model.Enum;
using System;

namespace eCopy.Model.Requests
{
    public class UpdateEmployeeRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Gender Gender { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] ProfilePhoto { get; set; }
        public string ProfilePhotoName { get; set; }
        public string ProfilePhotoExtension { get; set; }
    }
}
