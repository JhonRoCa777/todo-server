using DOMAIN.Exceptions.Types;
using INFRASTRUCTURE.Clases;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;

namespace INFRASTRUCTURE.Filters
{
    public class IsAuthFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var _JwtRepository = context.HttpContext.RequestServices.GetRequiredService<JwtUtils>();
            var _JwtSettingsDTO = context.HttpContext.RequestServices.GetRequiredService<JwtSettingsDTO>();

            var Token = context.HttpContext.Request.Cookies[_JwtSettingsDTO.Name];

            var Principal = _JwtRepository.ValidateToken(Token!);

            var SubClaim = Principal.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)
                ?? throw new UserNotAuthException();

            context.HttpContext.Items[_JwtSettingsDTO.Name] = SubClaim.Value;
        }
    }
}
