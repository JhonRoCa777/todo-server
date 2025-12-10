using INFRASTRUCTURE.Middleware;

namespace INFRASTRUCTURE.Config
{
    public static class App_Middleware
    {
        public static WebApplication UseMiddleware(this WebApplication app)
        {
            app.UseMiddleware<HandlerGlobalExceptionMiddleware>();
            app.UseMiddleware<ValidatorMiddleware>();
            return app;
        }
    }
}
