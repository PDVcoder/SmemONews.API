using Microsoft.AspNetCore.Mvc;
using SmemONews.BLL.Infrastructure;
using SmemONews.BLL.Interfaces;

namespace SmemONews.API.Controllers
{
    [Route("SmemONewsAPI/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet(nameof(LoginUser))]
        public IActionResult LoginUser(string login, string password)
        {
            try
            {
                var user = _loginService.LogIn(login, password);
                return Ok(user);
            }
            catch(ValidationException e)
            {
                return Ok($"Error: {e.Message}");
            }
        }
    }
}
