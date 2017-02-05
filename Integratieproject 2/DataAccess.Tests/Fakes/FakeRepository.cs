using System.Collections.Generic;
using Leisurebooker.Business.Domain;

namespace Leisurebooker.DataAccess.Tests.Fakes
{
    public class FakeRepository<T> : IRepository<T> where T : Entity
    {
        private readonly List<T> _entities;

        public FakeRepository()
        {
            this._entities = new List<T>();
        }

        public T Create(T entity)
        {
            entity.Id = this._entities.Count + 1;
            this._entities.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            this._entities.RemoveAt(id - 1);
        }

        public IEnumerable<T> Read(bool eager = false)
        {
            return this._entities;
        }

        public T Read(int id, bool eager = false)
        {
            return this._entities[id - 1];
        }

        public void Update(T entity)
        {
            this._entities[entity.Id - 1] = entity;
        }
    }
}