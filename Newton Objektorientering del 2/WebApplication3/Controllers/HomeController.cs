using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Unity;

namespace WebApplication3.Controllers
{
    public interface IBook
    {
        int Id { get; }
        string Category { get; }
        string Title { get; }
    }

    public class Book : IBook
    {
        private int id { get; set; }
        private string category { get; set; }
        private string title { get; set; }

        public int Id => id;
        public string Category => category;
        public string Title => title;

        public Book(int id, string category, string title)
        {
            this.id = id;
            this.category = category;
            this.title = title;
        }
    }


    public class LongBook : IBook
    {

        int IBook.Id => throw new NotImplementedException();

        string IBook.Category => throw new NotImplementedException();

        string IBook.Title => throw new NotImplementedException();
    }



    public interface IBookRepository
    {
        public void Add();
        public void Delete();
    }

    public class MikaelsBookRepository : IBookRepository
    {
        public void Add()
        {
            //throw new NotImplementedException();
        }

        public void Delete()
        {
            //throw new NotImplementedException();
        }
    }

    public class PetersBookRepository : IBookRepository
    {
        public void Add()
        {
            //throw new NotImplementedException();
        }

        public void Delete()
        {
            //throw new NotImplementedException();
        }
    }

    public interface IBookService
    {
        public void Add();
        public void Delete();
        public IBook GetBook();
    }


    public class PetersBookService : IBookService
    {
        public void Add()
        {
            //Sparar i SQL Databas
            //throw new NotImplementedException();
            //Data conncetion
            //Inser table
            //refresh
            //Save to dabasts

        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public IBook GetBook()
        {
            throw new NotImplementedException();
        }
    }


    public class LinasBookService : IBookService
    {
        public void Add()
        {
            //Sparar ner i en Oracle
            //throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public IBook GetBook()
        {
            return new Book(12, "Longbook", "Lord of the Rings");
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }


    public class HomeController : Controller
    {

        private readonly IBookService bookservice;
        private readonly IBookRepository bookrepository;
        //private readonly PetersBookService petersService;
        //private readonly LinasBookService linasService;

        //public HomeController()
        //{
        //    //this hides the service, we cannot test it when it is created in the constructor.
        //    //we use Dependency Injection to inject this service. 
        //    //Then the Controller will be better testable with injected service.
        //    bookservice = new LinasBookService();
        //}

        // DEPENDENCY INJECTION --->>>>  SE HÄR!!!!
        public HomeController(IBookService service, 
                              IBookRepository bookrepository)

        {
            //This is great!
            this.bookservice = service;
            this.bookrepository = bookrepository;
        }


        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet]
        //public ActionResult GetBook()
        //{
        //    var book = bookservice.GetBook();
        //    return new JsonResult { Data = book, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        public ActionResult GetBook()
        {
            IBook book;
            try
            {
                book = bookservice.GetBook();

                if (book.Title.StartsWith("A"))
                    book = new Book(1, "No category", "A");

                if (book != null)
                {
                    this.bookrepository.Delete();
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.ToString());
            }
            return new JsonResult { Data = book, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public ActionResult GetPerson()
        {
            var result = new Person { Id = 1, FirstName = "Peter", LastName = "Ladavats", Age = 39 };
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public ActionResult GetPersonFromId(int id)
        {
            IList<Person> personlist = new List<Person>();

            personlist.Add(new Person { Id = 1, FirstName = "Peter", LastName = "Ladavats", Age = 39 });
            personlist.Add(new Person { Id = 2, FirstName = "Jonas", LastName = "Andersson", Age = 52 });
            personlist.Add(new Person { Id = 3, FirstName = "Anders", LastName = "Svensson", Age = 19 });
            personlist.Add(new Person { Id = 4, FirstName = "Göran", LastName = "Karlsson", Age = 24 });

            var selectedPerson = personlist.Where(o => o.Id == id).FirstOrDefault();

            //Clean Code, alltid positiva först! Lättare för människan att ta till sig.
            if (selectedPerson == null)
                return new HttpStatusCodeResult(204);
            
            return new JsonResult { Data = selectedPerson, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        [HttpGet]
        public ActionResult GetListOfPersons()
        {
            IList<Person> personlist = new List<Person>();

            personlist.Add(new Person { Id = 1, FirstName = "Peter", LastName = "Ladavats", Age = 39 });
            personlist.Add(new Person { Id = 2, FirstName = "Jonas", LastName = "Andersson", Age = 52 });
            personlist.Add(new Person { Id = 3, FirstName = "Anders", LastName = "Svensson", Age = 19 });
            personlist.Add(new Person { Id = 4, FirstName = "Göran", LastName = "Karlsson", Age = 24 });

            return new JsonResult { Data = personlist, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            //return service.GetListOfPersons();
        }


        

        private void BookTestController(IBookService service)
        {
            service.Add();
            service.Delete();
        }

        [HttpPost]
        public ActionResult AddPerson(Person person)
        {
            //MED DEPENDENCY INJECTION
            this.bookservice.Add();
            this.bookrepository.Add();

            //UTAN DEPENDENCY INJECTION
            IBookService bookservice1 = new PetersBookService();
            bookservice1.Add();

            IBookService service2 = new LinasBookService();
            //BookTestController(service1);


            IList<Person> personlist = new List<Person>();

            personlist.Add(person);

            return new HttpStatusCodeResult(200);
        }

       
    }
}
