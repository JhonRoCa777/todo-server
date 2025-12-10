using APPLICATION.Ports.Input;
using DOMAIN.Entities;
using INFRASTRUCTURE.Clases;
using INFRASTRUCTURE.Filters;
using Microsoft.AspNetCore.Mvc;

namespace INFRASTRUCTURE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [IsAuthFilter]
    public class TodoController(ITodoService TodoService, JwtSettingsDTO JwtSettingsDTO)
            : ControllerBase
    {
        private readonly ITodoService _TodoService = TodoService;
        private readonly JwtSettingsDTO _JwtSettingsDTO = JwtSettingsDTO;

        [HttpGet]
        public async Task<IActionResult> Index()
            => Ok(await _TodoService.FindAllAsync(
                long.TryParse(HttpContext.Items[_JwtSettingsDTO.Name]?.ToString(), out var userId) ? userId : -1
            ));

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(long Id)
            => Ok(await _TodoService.GetAsync(Id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TodoRequest Request)
            => Ok(await _TodoService.CreateAsync(Request));

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(long Id, [FromBody] TodoRequest Request)
            => Ok(await _TodoService.UpdateAsync(Id, Request));

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
            => Ok(await _TodoService.DeleteAsync(Id));
    }
}
