using Fb.NewOrders.Business.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using FB.NewOrders.Business.Interfaces;

namespace FB.NewOrders.Business.Configuration
{
    public static class RedisConfig
    {
        public static void RegisterRedis(this IServiceCollection services, IConfiguration configuration)
        {
            var muxer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("ConexaoRedis"));
            services.AddScoped<IRedisService, RedisService>();
            services.AddSingleton<IConnectionMultiplexer>(muxer);
        }
    }
}