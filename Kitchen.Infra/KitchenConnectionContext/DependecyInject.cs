using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kitchen.Infra.KitchenConnectionContext
{
    public static class DependencyInject
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HotelDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("ConnectionString"),
                b => b.MigrationsAssembly(typeof(HotelDbContext).Assembly.FullName)),
                ServiceLifetime.Transient);

            services.AddScoped<IHotelDbContext, HotelDbContext>();

            return services;
        }
    }
}
