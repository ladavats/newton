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
    public class HomeController : Controller
    {
        private readonly string getCustomers = "https://localhost:44379/api/customers";
        public ActionResult Index()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(getCustomers).Result;
                if (response != null)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var customerResponse = JsonConvert.DeserializeObject<GetAllCustomersResponseDto>(jsonString);
                    ViewBag.Customers = customerResponse.Customers;
                }
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
