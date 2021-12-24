using System;

namespace SmemONews.BLL.DTO
{
    public class UserDTO : BaseUserDTO
    {
        public int Id { get; set; }
        //public string Firstname { get; set; }
        //public string Lastname { get; set; }
        public DateTime RegistrationDate { get; set; }
        //public DateTime Birthday { get; set; }
        //public string PhoneNumber { get; set; }
        //public string Email { get; set; }
        //public string Login { get; set; }
        //public string PasswordHash { get; set; }
        //public int RoleId { get; set; }
        public RoleDTO Role { get; set; }
    }
}
