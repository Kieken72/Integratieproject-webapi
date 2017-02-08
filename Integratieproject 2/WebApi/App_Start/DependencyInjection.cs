using System.Web.Http;
using Leisurebooker.Business;
using Leisurebooker.Business.Domain;
using Leisurebooker.Business.Services;
using Microsoft.Practices.Unity;
using WebApi.Models;

namespace WebApi
{
    public static class DependencyInjection
    {
        internal static void Configue(HttpConfiguration config)
        {
            var container = new UnityContainer();

            container.RegisterType<IService<Company>, CompanyService>(new HierarchicalLifetimeManager());
            container.RegisterType<IService<City>, CityService>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}