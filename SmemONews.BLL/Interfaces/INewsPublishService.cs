using SmemONews.BLL.DTO;
using System.Collections.Generic;

namespace SmemONews.BLL.Interfaces
{
    public interface INewsPublishService
    {
        void PublishNews(BaseNewsDTO newsDTO);
        ICollection<HeadingDTO> GetHeadings();
        void Dispose();
    }
}
