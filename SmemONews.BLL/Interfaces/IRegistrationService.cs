using SmemONews.BLL.DTO;

namespace SmemONews.BLL.Interfaces
{
    public interface IRegistrationService
    {
        void Registrate(BaseUserDTO userDTO);
        void Dispose();
    }
}
