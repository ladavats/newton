using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    
    
    //Data Transfer Object (DTO)- VI SKALL FLYTTA UT DETTA
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly string urlGetPerson = "https://localhost:44394/Home/GetPerson";
        private readonly string urlAddPerson = "https://localhost:44394/Home/AddPerson";

        public ActionResult Index()
        {
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

        public ActionResult GetPerson()
        {
            

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(urlGetPerson).Result; //GetAsync utan Result.
                if (response != null)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    var person = JsonConvert.DeserializeObject<Person>(jsonString);
                    ViewBag.Message = "Tack för att du hämtade en person med förnamn: " + person.FirstName;
                }
            }
            return View("About");
        }

        //Denna kan göras till Async - men inte nu.
        public ActionResult AddPerson()
        {
            Person personToSendToServerDTO = new Person
            {
                Id = 100,
                FirstName = "Peter",
                LastName = "Ladavats",
                Age = 39
            };

            //Samma sak som Person objekt fast i sträng. Så här vill vi inte arbeta.
            //string jsonPerson = "{\"Id\":1,\"FirstName\":\"Peter\",\"LastName\":\"Ladavats\",\"Age\":39}";

            using (HttpClient client = new HttpClient())
            {
                var personJsonString = JsonConvert.SerializeObject(personToSendToServerDTO);
                var content = new StringContent(personJsonString, Encoding.UTF8, "application/json");
                var response = client.PostAsync(urlAddPerson, content).Result; //PostAsync utan Result.
            }

            ViewBag.Message = "Tack för att du lade till en person";
            return View("About");
        }
    }
}