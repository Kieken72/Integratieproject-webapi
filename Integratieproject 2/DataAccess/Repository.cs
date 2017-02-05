using System.Collections.Generic;
using Leisurebooker.DataAccess.EF;
using Leisurebooker.DataAccess.EF.Connection;

namespace Leisurebooker.DataAccess
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected Context Context;

        public Repository(Context context)
        {
            this.Context = context;
        }

        public abstract T Create(T entity);
        public abstract IEnumerable<T> Read(bool eager = false);
        public abstract T Read(int id, bool eager = false);
        public abstract void Update(T entity);
        public abstract void Delete(int id);
    }
}
