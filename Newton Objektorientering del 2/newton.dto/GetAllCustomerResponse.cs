using System;
using System.Collections.Generic;
using System.Text;

namespace newton.dto
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Info { get; set; }

    }
    public class GetAllCustomersResponse
    {
        public List<CustomerDto> Customers { get; set; } = new List<CustomerDto>();
    }
}
