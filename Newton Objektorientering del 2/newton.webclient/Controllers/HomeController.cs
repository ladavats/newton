﻿using newton.dto;
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
        private readonly IApiEndpoints _apiendpoints;
        public HomeController()
        {
            _apiendpoints = new AzureApiEndpoints();
        }
        public ActionResult Index()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(_apiendpoints.GetCustomers).Result;
                if (response != null)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var customerResponse = JsonConvert.DeserializeObject<GetAllCustomersResponseDto>(jsonString);

                    var customers = new List<CustomerListModel>();
                    foreach (var customer in customerResponse.Customers)
                    {
                        var customerListModel = new CustomerListModel
                        {
                            FirstName = customer.FirstName,
                            LastName = customer.LastName,
                            SocialSecurityNumber = customer.SocialSecurityNumber,
                            YearlySalary = customer.YearlySalary,
                            Info = customer.Info,
                            City = "No city in database"

                        };
                        customers.Add(customerListModel);
                    }
                    ViewBag.Customers = customers;
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
