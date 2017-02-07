using Leisurebooker.Business.Domain;
using Leisurebooker.DataAccess.Tests.Fakes;

namespace Leisurebooker.Business.Tests.Fakes
{
    public class FakeService<T> : Service<T> where T : Entity
    {
        public FakeService() : base(new FakeRepository<T>()) { }
    }
}
