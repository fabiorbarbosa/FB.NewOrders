using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using FB.NewOrders.Data.Context;
using FB.NewOrders.Domain.Entity;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FB.NewOrders.Domain.Interfaces;

namespace FB.NewOrders.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly NewOrdersDbContext _db;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(NewOrdersDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }

        public virtual async Task<int> Save(TEntity entity)
        {
            _dbSet.Add(entity);
            return await _db.SaveChangesAsync();
        }

        public virtual async Task<TEntity> Get(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IList<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _db.SaveChangesAsync();
        }

        public virtual async Task Delete(Guid id)
        {
            var entity = new TEntity{ Id = id };
            _dbSet.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}