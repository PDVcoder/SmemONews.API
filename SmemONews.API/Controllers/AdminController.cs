using Microsoft.AspNetCore.Mvc;
using SmemONews.BLL.Infrastructure;
using SmemONews.BLL.Interfaces;
using SmemONews.BLL.StaticDTO;

namespace SmemONews.API.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet(nameof(GetUsers))]
        public IActionResult GetUsers()
        {
            var users = _adminService.GetUsers();
            return Ok(users);
        }

        [HttpGet(nameof(GetUsersByStatus))]
        public IActionResult GetUsersByStatus(string status)
        {
            try
            {
                var users = _adminService.GetUsersByStatus(status);
                return Ok(users);
            }
            catch(ValidationException e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }

        [HttpGet(nameof(GetUsersByRole))]
        public IActionResult GetUsersByRole(string role)
        {
            try
            {
                var users = _adminService.GetUsersByRole(role);
                return Ok(users);
            }
            catch (ValidationException e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }

        [HttpDelete(nameof(DeleteUser))]
        public IActionResult DeleteUser(int? userId)
        {
            try
            {
                _adminService.DeleteUser(userId);
                return Ok($"User with id ({userId}) was deleted");
            }
            catch (ValidationException e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }

        [HttpPut(nameof(ChangeUserStatus))]
        public IActionResult ChangeUserStatus(int? userId, string status)
        {
            try
            {
                _adminService.ChangeUserStatus(userId, status);
                return Ok($"Status was changed by ({status.ToUpper()}) in user with id ({userId})");
            }
            catch (ValidationException e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }
    }
}
