using SmemONews.BLL.DTO;
using System.Collections.Generic;

namespace SmemONews.BLL.Interfaces
{
    public interface INewsModeratorService
    {
        ICollection<NewsDTO> GetNewsForCheck();
        void PublishNews(int? newsId, string status);
        void Dispose();
    }
}
