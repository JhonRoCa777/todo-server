using APPLICATION.Ports.Input;
using APPLICATION.Ports.Output;
using APPLICATION.Services;
using INFRASTRUCTURE.Adapters;
using INFRASTRUCTURE.Clases;

namespace INFRASTRUCTURE.Config
{
    public static class Builder_DependencyInjection
    {
        public static IServiceCollection AddDependencyInjectionService(this IServiceCollection services, IConfiguration configuration)
        {
            // Utils
            services.AddSingleton(configuration.GetSection("JwtSettings").Get<JwtSettingsDTO>()!);
            services.AddSingleton<JwtUtils>();

            // Services
            services.AddScoped<ITodoService, TodoService>();

            // Repository
            services.AddScoped<ITodoRepository, TodoRepository>();

            return services;
        }
    }
}
