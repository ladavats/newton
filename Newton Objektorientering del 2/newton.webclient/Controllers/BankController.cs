using newton.dto;
using newton.infrastructure.logging.logging;
using newton.infrastructure.logging.logging.interfaces;
using newton.webclient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace newton.webclient.Controllers
{
    public class BankController : Controller
    {
        private readonly IWebApiEndpoints _endpoints;
        private readonly ILogger _logger;
        public BankController()
        {
            _endpoints = new WebApiEndpoints();
            _logger = new AzureDatabaseLogger();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCustomer(CreateCustomerModel model)
        {
            var createCustomerRequest = new CreateCustomerRequestDto
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                SocialSecurityNumber = model.SocialSecurityNumber,
                YearlySalary = model.YearlySalary
            };

            try
            {
                string jsonCreateCustomer = JsonConvert.SerializeObject(createCustomerRequest);
                var httpContent = new StringContent(jsonCreateCustomer, Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    var response = client.PostAsync(new Uri(_endpoints.CreateCustomer), httpContent).Result;
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                        return View("Error");
                }
            }
            catch(Exception ex)
            {
                _logger.LogCriticalError("Could not create new Customer for UserInterface", ex.ToString());
            }

            _logger.LogInfo("Customer was created sucessfully");
            return View("~/Views/Customer/CustomerCreated.cshtml");
        }
    }
}