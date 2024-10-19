using HrSearchApp.Interfaces;
using HrSearchApp.Models;
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
        public IActionResult Login([FromBody] Hr hr)
        {
            if (string.IsNullOrEmpty(hr.Login) || string.IsNullOrEmpty(hr.Password))
            {
                return BadRequest("Логин и пароль не могут быть пустыми.");
            }

            var user = _hrRepository.AuthenticateAsync(hr.Login, hr.Password);

            if (user == null)
            {
                return Unauthorized("Неверный логин или пароль.");
            }

            if (user.Id <= 0)
            {
                return BadRequest("Некорректный идентификатор пользователя.");
            }

            return Ok(new { message = "Успешный вход", userId = user.Id });
        }
    }
}
