using System;
using System.Collections.Generic;
using System.Linq;
using TopTenMovies.DP.Providers;
using TopTenMovies.IDAL.Repositories;
using Newtonsoft.Json;

namespace TopTenMovies.DA.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DataAccessProvider _provider;

        public Repository(DataAccessProvider provider)
        {
            _provider = provider;
        }

        public void Add(TEntity entity)
        {
            var entityResult = _provider.Read<TEntity>();

            entityResult.Add(entity);

            _provider.Write(entityResult);
        }

        public void Add(IList<TEntity> entities)
        {
            _provider.Write(entities);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            var entityResult = _provider.Read<TEntity>();

            return entityResult.Where(predicate);
        }

        public IList<TEntity> GetAll()
        {
            return _provider.Read<TEntity>();
        }
    }
}