using Leisurebooker.Business.Domain;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leisurebooker.DataAccess.Tests.Fakes
{
    public static class FakeRepositoryFactory
    {
        public static IRepository<T> Create<T>() where T : Entity
        {
            return new FakeRepository<T>();
        }
    }
}
