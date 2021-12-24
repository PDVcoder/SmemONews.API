using Microsoft.AspNetCore.Mvc;
using SmemONews.BLL.DTO;
using SmemONews.BLL.Infrastructure;
using SmemONews.BLL.Interfaces;

namespace SmemONews.API.Controllers
{
    public class RegistrateController : Controller
    {
        private readonly IRegistrationService _registrationService;

        public RegistrateController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }
        
        [HttpPost(nameof(RegisterUser))]
        public IActionResult RegisterUser(BaseUserDTO user)
        {
            string result = "User registered successful";
            try
            {
                _registrationService.Registrate(user);
            }
            catch(ValidationException e)
            {
                result = $"Error - {e.Message}";
            }
            return Ok(result);
        }
    }
}
