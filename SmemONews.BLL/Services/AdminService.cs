using AutoMapper;
using SmemONews.BLL.BusinessModels;
using SmemONews.BLL.DTO;
using SmemONews.BLL.Infrastructure;
using SmemONews.BLL.Interfaces;
using SmemONews.BLL.StaticDTO;
using SmemONews.DAL.Entity;
using SmemONews.DAL.Interfaces;
using System.Collections.Generic;

namespace SmemONews.BLL.Services
{
    public class AdminService : IAdminService
    {
        private IUnitOfWork Database;
        public AdminService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public ICollection<UserDTO> GetNotRegisteredModerators()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.User.Find(e => e.Status.Equals(StatusValue.App)));
        }

        public ICollection<UserDTO> GetUsers()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.User.GetAll());
        }

        public ICollection<UserDTO> GetUsersByStatus(string status)
        {
            string statusUser = status.ToUpper();
            if (!StatusValidator.CheckStatus(statusUser)) throw new ValidationException($"This status {statusUser} doesn't exist", "");
            var mapper = new MapperConfiguration(config => config.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.User.Find(e => e.Status.Equals(statusUser)));
        }

        public ICollection<UserDTO> GetUsersByRole(string role)
        {
            string roleUser = role.ToLower();
            if (!RoleValidator.CheckRole(roleUser)) throw new ValidationException($"This status {roleUser} doesn't exist", "");
            var mapper = new MapperConfiguration(config => config.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.User.Find(e => e.Role.Name.Equals(roleUser)));
        }

        public void DeleteUser(int? userId)
        {
            if (userId == null) throw new ValidationException("User id is null","");
            Database.User.Delete(userId.Value);
            Database.Save();
        }

        public void ChangeUserStatus(int? userId, string status)
        {
            if (userId == null) throw new ValidationException("User Id is null", "");

            User user = Database.User.Get(userId.Value);

            if (user == null) throw new ValidationException("User was not found", "");

            string statusUser = status.ToUpper();
            if (!StatusValidator.CheckStatus(statusUser)) throw new ValidationException($"This status {statusUser} doesn't exist", "");

            user.Status = statusUser;
            Database.User.Update(user);
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
