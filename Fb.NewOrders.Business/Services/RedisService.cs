using System;
using StackExchange.Redis;
using System.Threading.Tasks;
using FB.NewOrders.Business.Interfaces;
using FB.NewOrders.Domain.Models;

namespace Fb.NewOrders.Business.Services
{
  public class RedisService : IRedisService
  {
    private readonly IConnectionMultiplexer _redisConnection;
    private readonly IDatabase _db;
    public RedisService(IConnectionMultiplexer redisConnection)
    {
        _redisConnection = redisConnection;
        _db = _redisConnection.GetDatabase();
    }

    public Task<bool> Add<TEntity>(TEntity entity, string id, int expireMinutes) where TEntity : Entity
    {
      throw new NotImplementedException();
    }

    public Task<TEntity> Get<TEntity>(string id) where TEntity : Entity
    {
      throw new NotImplementedException();
    }

    public Task<bool> Remove(string id)
    {
      throw new NotImplementedException();
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }
  }
}