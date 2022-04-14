using System;
using System.Threading.Tasks;
using FB.NewOrders.Domain.Models;

namespace FB.NewOrders.Business.Interfaces
{
    public interface IRedisService
    {
        Task<bool> Add<TEntity>(TEntity entity, string id, int expireMinutes) where TEntity : Entity;
        Task<TEntity> Get<TEntity>(string id) where TEntity : Entity;
        Task<bool> Remove(string id);
    }
}