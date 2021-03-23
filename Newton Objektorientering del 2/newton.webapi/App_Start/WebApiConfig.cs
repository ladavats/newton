﻿using newton.repository.repos;
using newton.repository.interfaces;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;
using newton.domain.models.bankaccount.services;
using newton.domain.models.bankaccount.interfaces;

namespace newton.webapi
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static void RegisterSimpleInjector(HttpConfiguration config)
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            // Register your types, for instance using the scoped lifestyle:
            container.Register<IBankAccountService, NordeaBankAccountService>(Lifestyle.Scoped);
            container.Register<ICustomerRepository, AzureSqlDataStorage> (Lifestyle.Scoped);
            container.Register<IInsuranceRepository, AzureSqlDataStorage>(Lifestyle.Scoped);
            container.Register<IBankAccountRepository, AzureSqlDataStorage>(Lifestyle.Scoped);
            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
