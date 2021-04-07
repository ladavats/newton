using newton.domain.models.bankaccount.interfaces;
using newton.domain.models.customer;
using newton.domain.models.customer.interfaces;
using newton.dto;
using newton.infrastructure.logging.logging.interfaces;
using newton.repository.interfaces;
using System;
using System.Web.Http;

namespace newton.webapi.Controllers
{
    public class BankController : ApiController
    {
        private readonly IBankAccountService _bankaccountservice;
        private readonly ICustomerRepository _customerRepository;
        private readonly IInsuranceRepository _insuranceRepository;
        private readonly IBankAccountRepository _bankaccountRepository;
        private readonly ILogger _logger;

        public BankController(IBankAccountService bankaccountservice,
                                ICustomerRepository customerRepository,
                                IInsuranceRepository insurancerepository,
                                IBankAccountRepository bankaccountRepository,
                                ILogger logger)
        {
            this._bankaccountservice = bankaccountservice;
            this._customerRepository = customerRepository;
            this._insuranceRepository = insurancerepository;
            this._bankaccountRepository = bankaccountRepository;
            this._logger = logger;
        }

        [HttpGet]
        [Route("api/bankaccount")]
        public IHttpActionResult GetBankAccount(int accountId)
        {
            return Ok();
        }

        
        [Authorize(Roles = "user")]
        [HttpGet]
        [Route("api/bankaccounts")]
        public IHttpActionResult GetAllBankAccounts()
        {
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("api/customers")]
        public IHttpActionResult GetAllCustomers()
        {
            var response = new GetAllCustomersResponseDto();
            foreach (var customer in _customerRepository.GetAllCustomers()) {
                response.Customers.Add(new CustomerDto() { 
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName, 
                    LastName = customer.LastName, 
                    SocialSecurityNumber = customer.SocialSecurityNumber, 
                    Info = customer.Info,
                    YearlySalary = customer.YearlySalary});
            }

            return Ok(response);
        }


        [Authorize(Roles = "createnewcustomer")]
        [HttpPost]
        [Route("api/customer")]
        public IHttpActionResult CreateCustomer(CreateCustomerRequestDto request)
        {
            try
            {
                ICustomer customer = CustomerFactory.CreateCustomer(request.FirstName,
                                                                    request.LastName,
                                                                    request.SocialSecurityNumber,
                                                                    request.YearlySalary,
                                                                    request.Info);


                _customerRepository.Create(customer);
            }
            catch(Exception exception)
            {
                _logger.LogError("Customer could not be created", exception.ToString());
            }

            _logger.LogInfo("Customer created successfully");
            return Ok();
        }
    }
}
