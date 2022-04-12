using System;
using System.Threading.Tasks;
using FB.NewOrders.Business.Models;

namespace FB.NewOrders.Business.Interfaces
{
    public interface IRedisService
    {
        Task<bool> Add<TEntity>(TEntity entity, string id, int expireMinutes);
        Task<TEntity> Get<TEntity>(string id);
        Task<bool> Remove(string id);
    }
}