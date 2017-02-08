using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leisurebooker.DataAccess.EF.Connection
{
    public class CheckAndMigrateDatabaseToLatestVersion<TContext, TMigrationsConfiguration>
    : IDatabaseInitializer<TContext>
    where TContext : DbContext
    where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
    {
        public virtual void InitializeDatabase(TContext context)
        {
            var migratorBase = ((MigratorBase)new DbMigrator(Activator.CreateInstance<TMigrationsConfiguration>()));
            if (migratorBase.GetPendingMigrations().Any())
                migratorBase.Update();
        }
    }
}
