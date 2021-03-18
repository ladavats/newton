using newton.dto;
using newton.repository.dto;
using newton.repository.interfaces;
using newton.webapi.Models;
using newton.webapi.Models.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace newton.webapi.Controllers
{
    public class BankAccountController : ApiController
    {
        private readonly IBankAccountService bankaccountservice;
        private readonly IRepository bankrepository;
        public BankAccountController(IBankAccountService bankaccountservice,
                                     IRepository bankrepository)
        {
            this.bankaccountservice = bankaccountservice;
            this.bankrepository = bankrepository;
        }

        [HttpGet]
        [Route("api/bankaccount")]
        public IHttpActionResult GetBankAccount(int customerId)
        {
            return Ok(bankaccountservice.GetBankAccount(customerId));
        }

        [HttpGet]
        [Route("api/bankaccounts")]
        public IHttpActionResult GetAllBankAccounts()
        {
            return Ok(bankaccountservice.GetAllBankAccounts());
        }


        [HttpPost]
        [Route("api/bankaccount")]
        public IHttpActionResult CreateBankAccount(CreateBankAccountRequest request)
        {


            var new_customer = new CreateCustomerDTO()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                SocialSecurityNumber = request.SocialSecurityNumber
            };
            bankrepository.CreateCustomer(new_customer);

            var new_bankaccount = new CreateBankAccountDTO
            {
                Balance = 100
            };
            bankrepository.CreateBankAccount(new_bankaccount);

            return Ok();
        }
    }
}
