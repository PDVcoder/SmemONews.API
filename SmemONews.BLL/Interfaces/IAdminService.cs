using SmemONews.BLL.DTO;
using System.Collections.Generic;

namespace SmemONews.BLL.Interfaces
{
    public interface IAdminService
    {
        ICollection<UserDTO> GetUsers();
        ICollection<UserDTO> GetUsersByStatus(string status);
        ICollection<UserDTO> GetUsersByRole(string role);
        void DeleteUser(int? userId);
        void ChangeUserStatus(int? userId, string status);
        void Dispose();
    }
}
