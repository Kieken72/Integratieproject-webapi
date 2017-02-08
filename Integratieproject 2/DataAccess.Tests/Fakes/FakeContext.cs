using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leisurebooker.DataAccess.EF;
using Leisurebooker.DataAccess.EF.Connection;

namespace Leisurebooker.DataAccess.Tests.Fakes
{
    public class FakeContext : Context
    {
        public FakeContext() : base("LeisurebookerDB_EFCodeFirst_Ninja_TEST")
        {
            Database.SetInitializer(new CheckAndMigrateDatabaseToLatestVersion<FakeContext, Migrations.Configuration>());
        }
    }
}
