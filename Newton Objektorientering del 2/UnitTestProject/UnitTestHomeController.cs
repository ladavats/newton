using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApplication3.Controllers;


namespace UnitTestProject
{
    [TestClass]
    public class UnitTestHomeController
    {
        private Person peterTestData = new Person { Age = 39, FirstName = "Peter", LastName = "Ladavats", Id = 1 };
        private Person andersTestData = new Person { Age = 29, FirstName = "Anders", LastName = "Andersson", Id = 2 };
        private IBookService bookService = new LinasBookService();
        private IBookRepository repositoryService = new MikaelsBookRepository();

        [TestMethod]
        public void TestAddPersonReturns200OK()
        {
            
            

            //Find and install latest version of MVC.
            var controllerToTest = new HomeController(bookService, repositoryService);
            Assert.ThrowsException<NotImplementedException>(() => controllerToTest.AddPerson(peterTestData));

        }


        [TestMethod]
        public void TestIndex()
        {
            //Find and install latest version of MVC.
            var controllerToTest = new HomeController(bookService, repositoryService);
            controllerToTest.Index();
        }

        [TestMethod]
        public void TestGetBookIsDeletedIfNotNull()
        {
            var mockBookService = new Mock<IBookService>();
            var mockRepositoryService = new Mock<IBookRepository>();

            mockBookService.Setup(o => o.GetBook()).Returns(new Book(12, "Longbook", "Lord of the Rings"));
            
            var controllerToTest = new HomeController(mockBookService.Object, mockRepositoryService.Object);

            var book = controllerToTest.GetBook();
            mockRepositoryService.Verify(o => o.Delete(), Times.Once);
        }

        [TestMethod]
        public void TestGetBookIsNotDeletedIfNull()
        {
            var mockBookService = new Mock<IBookService>();
            var mockRepositoryService = new Mock<IBookRepository>();

            var controllerToTest = new HomeController(mockBookService.Object, mockRepositoryService.Object);

            var book = controllerToTest.GetBook();
            mockRepositoryService.Verify(o => o.Delete(), Times.Never); 
        }


        [TestMethod]
        public void TestGetBook()
        {
            var service = new LinasBookService();
            var book = service.GetBook();
            Assert.IsNotNull(book);

        }


        [TestMethod]
        public void TestGetBookWithInternalServerError()
        {
            //Install package Moq
            var mockService = new Mock<IBookService>();

            mockService.Setup(o => o.GetBook()).Throws(new Exception("no internet connection available"));

            //Find and install latest version of MVC.
            var controllerToTest = new HomeController(mockService.Object, repositoryService);


            var result = controllerToTest.GetBook();

        }


    }
}
