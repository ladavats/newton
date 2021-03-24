using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newton.webclient.Models
{
    public class AzureApiEndpoints : IApiEndpoints
    {
        public string GetCustomers => "https://newtonwebapi.azurewebsites.net/api/customers";
        public string CreateCustomer => "https://newtonwebapi.azurewebsites.net/api/customer";
    }
}