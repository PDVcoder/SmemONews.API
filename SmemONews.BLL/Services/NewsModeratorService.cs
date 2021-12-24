using AutoMapper;
using SmemONews.BLL.BusinessModels;
using SmemONews.BLL.DTO;
using SmemONews.BLL.Infrastructure;
using SmemONews.BLL.Interfaces;
using SmemONews.BLL.StaticDTO;
using SmemONews.DAL.Entity;
using SmemONews.DAL.Interfaces;
using System.Collections.Generic;

namespace SmemONews.BLL.Services
{
    public class NewsModeratorService : INewsModeratorService
    {
        private IUnitOfWork Database;
        public NewsModeratorService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public ICollection<NewsDTO> GetNewsForCheck()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<News, NewsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<News>, List<NewsDTO>>(Database.News.Find(e => e.Status.Equals(StatusValue.App)));
        }

        public void PublishNews(int? newsId, string status)
        {
            if (newsId == null) throw new ValidationException("News ID is null", "");

            News news = Database.News.Get(newsId.Value);
            if (news == null) throw new ValidationException("News was not found", "");

            string statusNews = status.ToUpper();
            if (!StatusValidator.CheckStatus(statusNews)) throw new ValidationException($"This status {statusNews} doesn't exist", "");

            news.Status = statusNews;

            Database.News.Update(news);
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
