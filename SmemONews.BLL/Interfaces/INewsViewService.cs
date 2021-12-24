using SmemONews.BLL.DTO;
using System.Collections.Generic;

namespace SmemONews.BLL.Interfaces
{
    public interface INewsViewService
    {
        NewsDTO GetNews(int? newsId);
        ICollection<CommentDTO> GetComments(int? newsId);
        void Dispose();
    }
}
