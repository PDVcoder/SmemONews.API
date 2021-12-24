using SmemONews.BLL.DTO;

namespace SmemONews.BLL.Interfaces
{
    public interface ILoginService
    {
        UserDTO LogIn(string login, string passwordHash);
        void Dispose();
    }
}
