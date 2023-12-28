﻿using System.Linq.Expressions;

namespace Core.Repositories.Bases
{
    public interface IRepoBase<TEntity> : IDisposable where TEntity : class, new()
    {
        int Save();

        IQueryable<TEntity> Query(bool isNoTracking = false);

        void Add(TEntity entity, bool save = true);

        void Update(TEntity entity, bool save = true);

        void Delete(Expression<Func<TEntity, bool>> predicate, bool save = true);
    }
}
