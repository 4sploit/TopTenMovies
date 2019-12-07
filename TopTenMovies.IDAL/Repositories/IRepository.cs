using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TopTenMovies.IDAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Add(IList<TEntity> entities);
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        IList<TEntity> GetAll();
    }
}