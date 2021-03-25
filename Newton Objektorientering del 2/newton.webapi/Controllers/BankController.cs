using newton.domain.models.bankaccount.interfaces;
using newton.domain.models.customer;
using newton.domain.models.customer.interfaces;
using newton.dto;
using newton.repository.interfaces;
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
            ICustomer customer = CustomerFactory.CreateCustomer(request.FirstName, 
                                                                request.LastName, 
                                                                request.SocialSecurityNumber, 
                                                                request.YearlySalary,
                                                                request.Info);


            _customerRepository.Create(customer);

            return Ok();
        }
    }
}
