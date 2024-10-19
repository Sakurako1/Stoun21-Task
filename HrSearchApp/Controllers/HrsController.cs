using HrSearchApp.Interfaces;
using HrSearchApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace HrSearchApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrsController : ControllerBase
    {
        private readonly IHrRepository _hrRepository;


        public HrsController(IHrRepository hrRepository)
        {
            _hrRepository = hrRepository;
        }

        [HttpPost("login")]
        public IActionResult Login([FromForm] string login, [FromForm] string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Логин и пароль не могут быть пустыми.");
            }

            var user = _hrRepository.AuthenticateAsync(login, password);

            if (user == null)
            {
                return Unauthorized("Неверный логин или пароль.");
            }

            return Ok(new { message = "Успешный вход", userId = user.Id });
        }
    }
}
