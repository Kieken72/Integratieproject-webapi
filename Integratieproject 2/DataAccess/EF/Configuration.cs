using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;

namespace Leisurebooker.DataAccess.EF
{
    public class Configuration : DbConfiguration
    {
        protected internal Configuration()
        {
            this.SetDefaultConnectionFactory(new SqlConnectionFactory());
            this.SetProviderServices("System.Data.SqlClient",SqlProviderServices.Instance);
        }
    }
}
