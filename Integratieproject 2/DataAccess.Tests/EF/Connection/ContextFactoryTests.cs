using Leisurebooker.DataAccess.EF.Connection;
using NUnit.Framework;

namespace Leisurebooker.DataAccess.Tests.EF.Connection
{
    [TestFixture]
    public class ContextFactoryTests
    {
        [Test]
        public void ContextCannotBeNull()
        {
            Assert.NotNull(ContextFactory.GetContext());
        }

        [Test]
        public void ContextShouldBeRefreshed()
        {
            var context = ContextFactory.GetContext();

            ContextFactory.Refresh();

            var refresh = ContextFactory.GetContext();

            Assert.AreNotSame(context, refresh);
        }
    }
}
