using System;

namespace eCopy.Model.Response
{
    public class CopierResponse
    {
        public string ID { get; set; }

        public bool Active { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TimeSpan StartWorkingTime { get; set; }

        public TimeSpan EndWorkingTime { get; set; }

        public string Url { get; set; }

        public string PhoneNumber { get; set; }

        public int CityId { get; set; }

        public CityResponse City { get; set; }

        public ApplicationUserResponse User { get; set; }

        //public ProfilePhoto ProfilePhoto { get; set; }

        public int ApplicationUserId { get; set; }
    }
}
