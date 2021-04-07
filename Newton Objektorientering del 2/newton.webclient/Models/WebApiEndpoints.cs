using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace newton.webclient.Models
{
    public class WebApiEndpoints : IWebApiEndpoints
    {
        private string HostName => ConfigurationManager.AppSettings["HostName"];
        public string GetCustomers => HostName + "api/customers";
        public string CreateCustomer => HostName + "api/customer";
    }
}