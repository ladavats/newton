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
        private readonly IInsuranceRepository insurancerepository;

        public BankAccountController(IBankAccountService bankaccountservice,
                                     IRepository bankrepository,
                                     IInsuranceRepository insurancerepository)
        {
            this.bankaccountservice = bankaccountservice;
            this.bankrepository = bankrepository;
            this.insurancerepository = insurancerepository;
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
            var bankaccount = bankaccountservice.CreateBankAccount(request.FirstName, request.LastName, request.SocialSecurityNumber);

            //Incorrect AutoSync specification for member 'Id'.
            var new_customer = new CreateCustomerDTO()
            {
                FirstName = bankaccount.FirstName,
                LastName = bankaccount.LastName,
                SocialSecurityNumber = bankaccount.SocialSecurityNumber
            };
            bankrepository.CreateCustomer(new_customer);

            var new_bankaccount = new CreateBankAccountDTO
            {
                Balance = bankaccount.Balance
            };
            bankrepository.CreateBankAccount(new_bankaccount);

            var new_insurance = new CreateInsuranceDTO()
            {
                CustomerId = 1,
                Name = "Inkomstförsäkring",
                Description = "Denna försäkring gör att tu inte tappar inkomst vid arbetsbortfall"
            };

            insurancerepository.Create(new_insurance);


            return Ok();
        }
    }
}
