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
    public class LoginService : ILoginService
    {
        private IUnitOfWork Database;

        public LoginService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public UserDTO LogIn(string login, string passwordHash)
        {
            List<User> users = Database.User.FindWithIncludes(user => user.Login.Equals(login), x => x.Role).ToList();
            
            if (users.Count == 0) throw new ValidationException("User doesn't exist","");
            if (users.Count > 1) throw new ValidationException("Login error, exist more than one user with thos login. Please contact support", "");
           
            var user = users[0];

            if (!user.PasswordHash.Equals(passwordHash)) throw new ValidationException("Password does't match", "");
            if (!user.Status.Equals(StatusValue.Ok)) throw new ValidationException($"User status ({user.Status}) is not (OK)", "");

            return new UserDTO
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Birthday = user.Birthday,
                RegistrationDate = user.RegistrationDate,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                PasswordHash = user.PasswordHash,
                Login = user.Login,
                RoleId = user.RoleId,
                Role = new RoleDTO
                {
                    Id = user.Role.Id,
                    Name = user.Role.Name,
                    Description = user.Role.Description
                }
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
