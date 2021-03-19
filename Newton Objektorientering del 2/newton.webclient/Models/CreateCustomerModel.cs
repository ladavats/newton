using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newton.webclient.Models
{
    public class CreateCustomerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }

        public bool WasCheckBoxSelected { get; set; }
    }
}