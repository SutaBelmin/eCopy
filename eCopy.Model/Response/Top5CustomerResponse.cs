﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eCopy.Model.Response
{
    public class Top5CustomerResponse
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string CityName { get; set; }
        public double Revenue { get; set; }
    }
}
