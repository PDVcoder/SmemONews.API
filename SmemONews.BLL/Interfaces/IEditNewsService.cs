using SmemONews.BLL.DTO;
using System.Collections.Generic;

namespace SmemONews.BLL.Interfaces
{
    public interface IEditNewsService
    {
        ICollection<NewsDTO> GetOwnNewsDTO(int? userId);
        void Delete(int? newsIs);
        void Update(BaseNewsDTO baseNewsDTO, int? newsId);
        void Dispose();
    }
}
