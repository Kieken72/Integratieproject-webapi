using Leisurebooker.Business.Domain;

namespace Leisurebooker.Business.Tests.Fakes
{
    public static class FakeServiceFactory
    {
        public static IService<T> Create<T>() where T : Entity
        {
            return new FakeService<T>();
        }
    }
}