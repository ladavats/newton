using newton.dto;
using newton.repository.dto;
using newton.repository.interfaces;
using newton.webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace newton.webapi.Controllers
{
    public class BankController : ApiController
    {
        private readonly IBankAccountService _bankaccountservice;
        private readonly ICustomerRepository _customerRepository;
        private readonly IInsuranceRepository _insuranceRepository;
        private readonly IBankAccountRepository _bankaccountRepository;

        public BankController(IBankAccountService bankaccountservice,
                                ICustomerRepository customerRepository,
                                IInsuranceRepository insurancerepository,
                                IBankAccountRepository bankaccountRepository)
        {
            this._bankaccountservice = bankaccountservice;
            this._customerRepository = customerRepository;
            this._insuranceRepository = insurancerepository;
            this._bankaccountRepository = bankaccountRepository;
        }

        [HttpGet]
        [Route("api/bankaccount")]
        public IHttpActionResult GetBankAccount(int accountId)
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/bankaccounts")]
        public IHttpActionResult GetAllBankAccounts()
        {
            return Ok();
        }


        [HttpPost]
        [Route("api/bankaccount")]
        public IHttpActionResult CreateBankAccount(CreateBankAccountRequest request)
        {
            //var bankaccount = bankaccountservice.CreateBankAccount(request.FirstName, request.LastName, request.SocialSecurityNumber);

            //Incorrect AutoSync specification for member 'Id'.
            //var new_customer = new CreateCustomerDTO()
            //{
            //    FirstName = bankaccount.FirstName,
            //    LastName = bankaccount.LastName,
            //    SocialSecurityNumber = bankaccount.SocialSecurityNumber
            //};
            //bankrepository.CreateCustomer(new_customer);

            //var new_bankaccount = new CreateBankAccountDTO
            //{
            //    Balance = bankaccount.Balance
            //};
            //bankrepository.CreateBankAccount(new_bankaccount);

            //var new_insurance = new CreateInsuranceDTO()
            //{
            //    CustomerId = 1,
            //    Name = "Inkomstförsäkring",
            //    Description = "Denna försäkring gör att tu inte tappar inkomst vid arbetsbortfall"
            //};

            //insurancerepository.Create(new_insurance);


            return Ok();
        }
    }
}
