using FB.NewOrders.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Fb.NewOrders.Infra.Configuration
{
	public static class DbContextConfig
	{
		public static IServiceCollection RegisterDbContext(this IServiceCollection services, IConfiguration configuration) {
			return services.AddDbContext<NewOrdersDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
			);
		}
	}
}