using newton.dto;
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
        private readonly string createCustomerUrl = "https://localhost:44379/api/customer";

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

            string jsonCreateCustomer = JsonConvert.SerializeObject(createCustomerRequest);
            var httpContent = new StringContent(jsonCreateCustomer, Encoding.UTF8, "application/json");

            //Task, Threading example to understand Async / Syncront.
            //ÖVA PÅ DETTA!
            //System.Threading.Thread!
            Task.Run(() => WaitOneSecond()).ContinueWith(task => WaitFiveSeconds());
            
            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(new Uri(createCustomerUrl), httpContent).Result;
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return View("Error");
            }
            
            return View("~/Views/Customer/CustomerCreated.cshtml");
        }

        static void WaitOneSecond()
        {
            System.Threading.Thread.Sleep(1000);
        }

        static void WaitFiveSeconds()
        {
            System.Threading.Thread.Sleep(5000);
        }
    }


    
}