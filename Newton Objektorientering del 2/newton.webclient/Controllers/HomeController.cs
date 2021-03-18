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

        [HttpPost]
        public ActionResult CreateBankAccount(CreateBankAccount bankaccount)
        {
            string jsonCreateBankAccountDTOasString = JsonConvert.SerializeObject(bankaccount.GetDTO());
            var httpContent = new StringContent(jsonCreateBankAccountDTOasString, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsync(new Uri("UrlToWebApiCreateBankAccount"), httpContent).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return View("BankAccountCreated");

            }
            return View("BankAccountNotCreated");
        }
    }
}
    //public ActionResult GetPerson()
    //{


    //    using (HttpClient client = new HttpClient())
    //    {
    //        var response = client.GetAsync(urlGetPerson).Result; //GetAsync utan Result.
    //        if (response != null)
    //        {
    //            var jsonString = response.Content.ReadAsStringAsync().Result;
    //            var person = JsonConvert.DeserializeObject<Person>(jsonString);
    //            ViewBag.Message = "Tack för att du hämtade en person med förnamn: " + person.FirstName;
    //        }
    //    }
    //    return View("About");
    //}

    ////Denna kan göras till Async - men inte nu.
    //public ActionResult AddPerson()
    //{
    //    Person personToSendToServerDTO = new Person
    //    {
    //        Id = 100,
    //        FirstName = "Peter",
    //        LastName = "Ladavats",
    //        Age = 39
    //    };

    //    //Samma sak som Person objekt fast i sträng. Så här vill vi inte arbeta.
    //    //string jsonPerson = "{\"Id\":1,\"FirstName\":\"Peter\",\"LastName\":\"Ladavats\",\"Age\":39}";

    //    using (HttpClient client = new HttpClient())
    //    {
    //        var personJsonString = JsonConvert.SerializeObject(personToSendToServerDTO);
    //        var content = new StringContent(personJsonString, Encoding.UTF8, "application/json");
    //        var response = client.PostAsync(urlAddPerson, content).Result; //PostAsync utan Result.
    //    }

    //    ViewBag.Message = "Tack för att du lade till en person";
    //    return View("About");
    //}



    //class PetersWayOfCreateBankAccount : ICreateBankAccount
    //{
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string SocialSecurityNumber { get; set; }
    //}

