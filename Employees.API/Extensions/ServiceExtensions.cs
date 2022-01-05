using Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace Employees.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
        }
    }
}
