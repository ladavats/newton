﻿using System;
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
        public float YearlySalary { get; set; }

    }
    public class GetAllCustomersResponseDto
    {
        public IList<CustomerDto> Customers { get; set; } = new List<CustomerDto>();
    }
}
