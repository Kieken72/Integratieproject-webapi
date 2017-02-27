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
            container.RegisterType<IService<Branch>, BranchService>(new HierarchicalLifetimeManager());
            container.RegisterType<IService<Space>, SpaceService>(new HierarchicalLifetimeManager());
            container.RegisterType<IService<Room>, RoomService>(new HierarchicalLifetimeManager());
            container.RegisterType<IService<Reservation>, ReservationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IService<Message>, MessageService>(new HierarchicalLifetimeManager());
            container.RegisterType<IService<Review>, ReviewService>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}