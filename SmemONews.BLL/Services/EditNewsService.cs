using AutoMapper;
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
    public class EditNewsService : IEditNewsService
    {
        private IUnitOfWork Database;
        public EditNewsService (IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Delete(int? newsId)
        {
            if(newsId == null) throw new ValidationException("NewsId is null", "");
            try
            {
                Database.News.Delete(newsId.Value);
                Database.Save();
            }
            catch(Exception e)
            {
                throw new ValidationException(e.Message, "");
            }    
        }

        public ICollection<NewsDTO> GetOwnNewsDTO(int? userId)
        {
            if (userId == null) throw new ValidationException("UserId is null", "");

            var mapper = new MapperConfiguration(config => config.CreateMap<News, NewsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<News>, List<NewsDTO>>(Database.News.FindWithIncludes(e => e.UserId == userId.Value, x => x.Heading));
        }

        public void Update(BaseNewsDTO baseNewsDTO, int? newsId)
        {
            if (newsId == null) throw new ValidationException("NewsId is null", "");

            string status = StatusValue.App;

            News news = new News
            {
                Id = newsId.Value,
                Name = baseNewsDTO.Name,
                Title = baseNewsDTO.Title,
                Text = baseNewsDTO.Text,
                HeadingId = baseNewsDTO.HeadingId,
                UserId = baseNewsDTO.UserId,
                Status = status
            };

            List<Tag> tags = new List<Tag>();
            List<int> tagsId = new List<int>();

            if(baseNewsDTO.Tags != null)
            {
                foreach (var tag in baseNewsDTO.Tags)
                {
                    if (Database.Tag.Count(e => e.Name.Equals(tag)) == 0)
                    {
                        tags.Add(new Tag { Name = tag });
                    }
                    else
                    {
                        tagsId.Add(Database.Tag.Find(e => e.Name.Equals(tag)).ToList()[0].Id);
                    }
                }
            }
            

            news.NewsTags = new List<TagsInNews>();
            foreach (var tag in tags)
            {
                news.NewsTags.Add(new TagsInNews
                {
                    News = news,
                    Tag = tag
                });
            }

            foreach (var tagId in tagsId)
            {
                news.NewsTags.Add(new TagsInNews
                {
                    News = news,
                    TagId = tagId
                });
            }
            Database.News.Update(news);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
