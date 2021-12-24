using AutoMapper;
using SmemONews.BLL.BusinessModels;
using SmemONews.BLL.DTO;
using SmemONews.BLL.Infrastructure;
using SmemONews.BLL.Interfaces;
using SmemONews.BLL.StaticDTO;
using SmemONews.DAL.Entity;
using SmemONews.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmemONews.BLL.Services
{
    public class NewsFilterService : INewsFilterService
    {
        private IUnitOfWork Database;
 
        public NewsFilterService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public ICollection<HeadingDTO> GetHeadings()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<Heading, HeadingDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Heading>, List<HeadingDTO>>(Database.Heading.GetAll());
        }

        public ICollection<NewsDTO> GetNews()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<News, NewsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<News>, List<NewsDTO>>(Database.News.Find(e => e.Status.Equals(StatusValue.Ok)));
        }
        public ICollection<NewsDTO> GetNewsByTag(string tag)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<News, NewsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<News>, List<NewsDTO>>(Database.News.Find(e => e.NewsTags.Where(ex => ex.Tag.Name.Contains(tag)).ToList().Count > 0 && e.Status.Equals(StatusValue.Ok)));
        }

        public ICollection<NewsDTO> GetNewsByNameOrTitle(string nameOrTitle)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<News, NewsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<News>, List<NewsDTO>>(Database.News.Find(e => e.Name.Contains(nameOrTitle) || e.Title.Contains(nameOrTitle) && e.Status.Equals(StatusValue.Ok)));
        }

        public ICollection<NewsDTO> GetNewsByDateRange(DateTime? firstDate, DateTime? secondDate)
        {
            if (firstDate == null) throw new ValidationException("First date is null", "");
            if (secondDate == null) throw new ValidationException("Second date is null", "");
            var mapper = new MapperConfiguration(config => config.CreateMap<News, NewsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<News>, List<NewsDTO>>(Database.News.Find(e => e.PublishDate.CompareTo(firstDate.Value) > 0 && e.PublishDate.CompareTo(secondDate.Value) < 0 && e.Status.Equals(StatusValue.Ok)));
        }

        public ICollection<NewsDTO> GetNewsByHeading(int? headingId)
        {
            if (headingId == null) throw new ValidationException("Heading id is null", "");
            var mapper = new MapperConfiguration(config => config.CreateMap<News, NewsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<News>, List<NewsDTO>>(Database.News.Find(e => e.HeadingId == headingId.Value && e.Status.Equals(StatusValue.Ok)));
        }

        public ICollection<NewsDTO> GetNewsByFilter(NewsFilter newsFilter)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<News, NewsDTO>()).CreateMapper();
            List<NewsDTO> titleAndNameNews = new List<NewsDTO>();
            List<NewsDTO> headingNews = new List<NewsDTO>();
            List<NewsDTO> dateNews = new List<NewsDTO>();
            List<NewsDTO> tagsNews = new List<NewsDTO>();

            if (newsFilter.TitleOrName != null)
            {
                titleAndNameNews = mapper.Map<IEnumerable<News>, List<NewsDTO>>(Database.News.Find(e => e.Name.Contains(newsFilter.TitleOrName) || e.Title.Contains(newsFilter.TitleOrName)));
            }
            if (newsFilter.HeadingId != null)
            {
                headingNews = mapper.Map<IEnumerable<News>, List<NewsDTO>>(Database.News.Find(e => e.HeadingId == newsFilter.HeadingId.Value));
            }
            if (newsFilter.FirstDate != null || newsFilter.SecondDate != null)
            {
                dateNews = mapper.Map<IEnumerable<News>, List<NewsDTO>>(Database.News.Find(e => e.PublishDate.CompareTo(newsFilter.FirstDate.Value) > 0 && e.PublishDate.CompareTo(newsFilter.SecondDate.Value) < 0));
            }

            tagsNews = mapper.Map<IEnumerable<News>, List<NewsDTO>>(Database.News.Find(e => e.NewsTags.Where(ex => ex.Tag.Name.Contains(newsFilter.Tag)).ToList().Count > 0));

            SortedSet<NewsDTO> result = new SortedSet<NewsDTO>(titleAndNameNews);
            result.IntersectWith(new SortedSet<NewsDTO>(headingNews));
            result.IntersectWith(new SortedSet<NewsDTO>(dateNews));
            result.IntersectWith(new SortedSet<NewsDTO>(tagsNews));
            return titleAndNameNews;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
