using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fb.NewOrders.Infra.Configuration
{
    public static class DIConfig
    {
        public static IServiceCollection AddDI(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}