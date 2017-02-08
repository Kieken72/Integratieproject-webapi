using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Leisurebooker.Business;
using Leisurebooker.Business.Domain;
using Leisurebooker.Business.Services;
using Microsoft.Practices.Unity;
using WebApi.Models;
using WebApi.Models.Dto;
using WebApi.Models.Mapping;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //Mapper
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CompanyProfile>();
                cfg.AddProfile<CityProfile>();
            });

            //Mapper = mCfg.CreateMapper();

            #region DI
            var container = new UnityContainer();
            
            container.RegisterType<IService<Company>, CompanyService>(new HierarchicalLifetimeManager());
            container.RegisterType<IService<City>, CityService>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);
#endregion
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
