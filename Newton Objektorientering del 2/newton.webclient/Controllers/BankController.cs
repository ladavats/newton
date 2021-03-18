using newton.dto;
using newton.webclient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace newton.webclient.Controllers
{
    public class BankController : Controller
    {
        private readonly string createCustomerUrl = "https://localhost:44379/api/customer";
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCustomer(CreateCustomerModel model)
        {
            var createCustomerRequest = new CreateCustomersRequest
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                SocialSecurityNumber = model.SocialSecurityNumber
            };

            string jsonCreateCustomer = JsonConvert.SerializeObject(createCustomerRequest);
            var httpContent = new StringContent(jsonCreateCustomer, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(new Uri(createCustomerUrl), httpContent).Result;
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return View("Error");
            }
            
            
            return View("~/Views/Customer/CustomerCreated.cshtml");
        }
    }
}