using SmemONews.BLL.DTO;
using SmemONews.BLL.Infrastructure;
using SmemONews.BLL.Interfaces;
using SmemONews.BLL.StaticDTO;
using SmemONews.DAL.Entity;
using SmemONews.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SmemONews.BLL.Services
{
    public class RegistrationService : IRegistrationService
    {
        private IUnitOfWork Database;
        public RegistrationService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Registrate(BaseUserDTO userDTO)
        {
            List<User> usersLogin = Database.User.Find(item => item.Login.Equals(userDTO.Login)).ToList();
            if (usersLogin.Count != 0) throw new ValidationException("User with this login already exist", "");

            List<User> usersEmail = Database.User.Find(item => item.Email.Equals(userDTO.Email)).ToList();
            if (usersEmail.Count != 0) throw new ValidationException("User with this email already exist", "");

            string status = StatusValue.Ok;

            if (userDTO.RoleId == 2) status = StatusValue.App;

            //List<Role> roles = Database.Role.Find(item => item.Name.Equals(userDTO.Role.Name)).ToList();
            //if (roles.Count == 0) throw new ValidationException("Role doesn't exist", "");
            //if (roles.Count > 1) throw new ValidationException("Exists more than one instance of this role in database. Please contact support", "");

            //Role role = roles[0];

            Database.User.Create(new User 
            {
                Firstname = userDTO.Firstname,
                Lastname = userDTO.Lastname,
                Birthday = userDTO.Birthday,
                Email = userDTO.Email,
                PhoneNumber = userDTO.PhoneNumber,
                Login = userDTO.Login,
                PasswordHash = userDTO.PasswordHash,
                Status = status,
                RoleId = userDTO.RoleId
            });
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
