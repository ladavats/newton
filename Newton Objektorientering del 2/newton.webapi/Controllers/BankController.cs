using newton.domain.models.customer;
using newton.dto;
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
        [Route("api/customer")]
        public IHttpActionResult CreateCustomer(CreateCustomerRequest request)
        {
            var customer = new Customer(request.FirstName, request.LastName, request.SocialSecurityNumber);
            _customerRepository.Create(customer);

            return Ok();
        }
    }
}
