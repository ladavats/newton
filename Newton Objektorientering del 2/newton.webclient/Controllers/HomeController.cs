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
                var response = client.PostAsync(new Uri("UrlToWebApiCreateBankAccount"), httpContent).Result; //GetAsync utan Result.
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return View("BankAccountCreated");

            }
            return View("BankAccountNotCreated");
        }
    }

    //class PetersWayOfCreateBankAccount : ICreateBankAccount
    //{
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string SocialSecurityNumber { get; set; }
    //}
}