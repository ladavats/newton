using newton.webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace newton.webapi.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly IBankAccountService bankaccountservice;

        public CustomerController(IBankAccountService bankaccountservice)
        {
            this.bankaccountservice = bankaccountservice;
        }
    }
}
