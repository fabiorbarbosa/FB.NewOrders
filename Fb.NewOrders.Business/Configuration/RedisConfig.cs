using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace FB.NewOrders.Business.Configuration
{
    public static class RedisConfig
    {
        public static void RegisterRedis(this IServiceCollection services, IConfiguration configuration)
        {
            var muxer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("ConexaoRedis"));
            services.AddSingleton<IConnectionMultiplexer>(muxer);
        }
    }
}