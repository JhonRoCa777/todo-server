using DOMAIN.Exceptions;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace INFRASTRUCTURE.Middleware
{
    public class HandlerGlobalExceptionMiddleware(RequestDelegate Next)
    {
        private readonly RequestDelegate _Next = Next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _Next(context);
            }
            catch (Exception ex)
            {
                await HandleAsync(context, ex);
            }
        }

        private static Task HandleAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;
            Object ErrorMessage = new { message = "An unexpected error occurred." };

            switch (ex)
            {
                case CustomException myEx:
                    StatusCode = myEx.ErrorCode;
                    ErrorMessage = new { message = myEx.Message };
                    break;

                case ValidationException myEx:
                    StatusCode = HttpStatusCode.UnprocessableEntity;
                    ErrorMessage = myEx.Errors
                        .GroupBy(e => e.PropertyName)
                        .ToDictionary(
                            g => g.Key,
                            g => g.Select(e => e.ErrorMessage).ToArray()
                        );
                    break;
            }

            if (StatusCode == HttpStatusCode.InternalServerError) throw ex;

            context.Response.StatusCode = (int)StatusCode;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(JsonSerializer.Serialize(ErrorMessage));
        }
    }
}
