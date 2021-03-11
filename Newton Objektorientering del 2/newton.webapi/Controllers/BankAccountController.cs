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
        
        public BankAccountController(IBankAccountService bankaccountservice)
        {
            this.bankaccountservice = bankaccountservice;
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
            var createdaccount = bankaccountservice.CreateBankAccount(request.FirstName, request.LastName, request.SocialSecurityNumber);
            //repositoryservice.Create(createdaccount);
            return Ok();

        }


    }
}
