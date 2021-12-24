using SmemONews.BLL.BusinessModels;
using SmemONews.BLL.DTO;
using System;
using System.Collections.Generic;

namespace SmemONews.BLL.Interfaces
{
    public interface INewsFilterService
    {
        ICollection<NewsDTO> GetNews();
        ICollection<NewsDTO> GetNewsByTag(string tag);
        ICollection<NewsDTO> GetNewsByNameOrTitle(string nameOrTitle);
        ICollection<NewsDTO> GetNewsByDateRange(DateTime? firstDate, DateTime? secondDate);
        ICollection<NewsDTO> GetNewsByHeading(int? headingId);
        ICollection<NewsDTO> GetNewsByFilter(NewsFilter newsFilter);
        ICollection<HeadingDTO> GetHeadings();
        void Dispose();
    }
}
