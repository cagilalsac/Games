using Core.Repositories.Bases;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Repositories.EntityFramework.Bases
{
    public abstract class RepoBase<TEntity> : IRepoBase<TEntity> where TEntity : class, new()
    {
        protected readonly DbContext _db;

        protected RepoBase(DbContext db)
        {
            _db = db;
        }

        public virtual IQueryable<TEntity> Query(bool isNoTracking = false)
        {
            return isNoTracking ? _db.Set<TEntity>().AsNoTracking() : _db.Set<TEntity>();
        }

        public virtual void Add(TEntity entity, bool save = true)
        {
            _db.Set<TEntity>().Add(entity);
            if (save)
                Save();
        }

        public virtual void Update(TEntity entity, bool save = true)
        {
            _db.Set<TEntity>().Update(entity);
            if (save)
                Save();
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate, bool save = true)
        {
            var entities = Query().Where(predicate).ToList();
            _db.Set<TEntity>().RemoveRange(entities);
            if (save)
                Save();
        }

        public virtual int Save()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            _db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
