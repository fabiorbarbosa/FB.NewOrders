using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FB.NewOrders.Domain.Models;

namespace FB.NewOrders.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
         Task<TEntity> Get(Guid id);
         Task<IList<TEntity>> GetAll();
         Task Update(TEntity entity);
         Task Delete(Guid id);
         Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
         Task<int> Save(TEntity entity);

    }
}