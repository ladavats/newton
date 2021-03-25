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
    public class UserIdentity
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly IApiEndpoints _apiendpoints;
        public HomeController()
        {
            _apiendpoints = new AzureApiEndpoints();
        }

        private string GetToken(string username, string password)
        {
            //HttpClient mot Token URL.
            //Mot Web Api för att hämta Token
            return "dsafdfasdfasdfa1234jk132h4lk12jhasdlkjhfaslkdhfj123423452345";
        }

        public ActionResult LoginUser(string username, string password)
        {
            string token = GetToken(username, password);
            if (string.IsNullOrEmpty(token))
                return View("LoginErrorView");

            var ui = new UserIdentity
            {
                UserName = username,
                Token = token
            };

            var loggedInUsers = new List<UserIdentity>();
            loggedInUsers.Add(ui);
            Session["OurBearerToken"] = loggedInUsers;

            return View("LoginSuccess");
        }
        public ActionResult Index()
        {
            //Först:
            //Hämta Token mot /Token med Username och Password
                //Logga in
                    //Authenticated - Yes / No
                    //Claims - Authorization - What, Admin, Client Roles.
                    //Add Token to HttpClient Header
                    //Key               Value
                    //Authorization      Bearer xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

            using (HttpClient client = new HttpClient())
            {
                var token = Session["OurBearerToken"].ToString(); //Where Username == username;
                client.DefaultRequestHeaders.Add("Authorization", token);
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
