using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newton.webclient.Models
{
    public class LocalApiEndpoints : IApiEndpoints
    {
        public string GetCustomers => "https://localhost:44379/api/customers";
        public string CreateCustomer => "https://localhost:44379/api/customer";
    }
}