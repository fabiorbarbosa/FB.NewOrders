using StackExchange.Redis;
using Fb.NewOrders.Business.Services;
using FB.NewOrders.Business.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fb.NewOrders.Infra.Configuration
{
    public static class RedisConfig
    {
        public static IServiceCollection RegisterRedis(this IServiceCollection services, IConfiguration configuration)
        {
            var muxer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
            services.AddScoped<IRedisService, RedisService>();
            services.AddSingleton<IConnectionMultiplexer>(muxer);
            return services;
        }
    }
}