using INFRASTRUCTURE.Models;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Config
{
    public static class Builder_DBContext
    {
        public static void AddDBContextService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseLazyLoadingProxies()
                       .UseSqlServer(connectionString)
            );
        }
    }
}
