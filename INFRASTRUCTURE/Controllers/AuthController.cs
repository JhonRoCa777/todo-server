using APPLICATION.Ports.Output;
using DOMAIN.Entities;
using INFRASTRUCTURE.Clases;
using Microsoft.AspNetCore.Mvc;

namespace INFRASTRUCTURE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(
            JwtUtils JwtUtils, JwtSettingsDTO JwtSettingsDTO,
            IUserRepository UserRepository
        ) : ControllerBase
    {
        private readonly JwtUtils _JwtUtils = JwtUtils;
        private readonly JwtSettingsDTO _JwtSettingsDTO = JwtSettingsDTO;
        private readonly IUserRepository _UserRepository = UserRepository;

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] UserLogin Request)
        {
            var Result = await _UserRepository.FindByCredentialsAsync(Request.Email, Request.Password);

            var token = _JwtUtils.GenerateToken(Result.Id.ToString());

            Response.Cookies.Append(_JwtSettingsDTO.Name, token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddMinutes(_JwtSettingsDTO.ExpireMinutes)
            });

            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult Verify()
        {
            var token = Request.Cookies[_JwtSettingsDTO.Name];
            _JwtUtils.ValidateToken(token!);
            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete(_JwtSettingsDTO.Name);
            return Ok();
        }
    }
}
