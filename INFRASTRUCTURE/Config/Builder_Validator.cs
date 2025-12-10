using INFRASTRUCTURE.Validators;
using FluentValidation;

namespace INFRASTRUCTURE.Config
{
    public static class Builder_Validator
    {
        public static IServiceCollection AddValidatorService(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<TodoRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<UserLoginValidator>();
            return services;
        }
    }
}
