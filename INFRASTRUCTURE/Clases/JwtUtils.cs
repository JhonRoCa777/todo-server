using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DOMAIN.Exceptions.Types;
using Microsoft.IdentityModel.Tokens;

namespace INFRASTRUCTURE.Clases
{
    public class JwtSettingsDTO
    {
        public string Key { get; set; } = string.Empty;

        public int ExpireMinutes { get; set; } = 0;

        public string Name { get; set; } = string.Empty;
    }

    public class JwtUtils(JwtSettingsDTO Settings)
    {
        private readonly JwtSettingsDTO _Settings = Settings;

        public string GenerateToken(string UserId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_Settings.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, UserId)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_Settings.ExpireMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal ValidateToken(string Token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler
                {
                    MapInboundClaims = false
                };

                var key = Encoding.UTF8.GetBytes(_Settings.Key);

                return tokenHandler.ValidateToken(Token, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero
                }, out _);
            }
            catch
            {
                throw new UserNotAuthException();
            }
        }
    }
}
