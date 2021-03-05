using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication3.Controllers;


namespace WebApplication3
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           
            //IFYLLT FRÅN BÖRJAN. JAG HAR INTE SKRIVIT DETTA.
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //HÄR KOMMER SIMPLE INJECTOR koden:
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            //THE COOL STUFF!
            //Kan göras mer abstrakt och hämtas från config.

            bool isCompanySqlSupported = false; //Vi säger att denna hämtas från config också.
            if (isCompanySqlSupported)
                container.Register<IBookService, PetersBookService>(Lifestyle.Scoped);
            else
                container.Register<IBookService, LinasBookService>(Lifestyle.Scoped);

            container.Register<IBookRepository, MikaelsBookRepository>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));


        }
    }
}
