using AutoMapper;
using SmemONews.BLL.DTO;
using SmemONews.BLL.Infrastructure;
using SmemONews.BLL.Interfaces;
using SmemONews.BLL.StaticDTO;
using SmemONews.DAL.Entity;
using SmemONews.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SmemONews.BLL.Services
{
    public class NewsPublishService : INewsPublishService
    {
        private IUnitOfWork Database;
        public NewsPublishService(IUnitOfWork uow) 
        {
            Database = uow;
        }

        public ICollection<HeadingDTO> GetHeadings()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<Heading, HeadingDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Heading>, List<HeadingDTO>>(Database.Heading.GetAll());
        }

        public void PublishNews(BaseNewsDTO baseNewsDTO)
        {
            string status = StatusValue.App;

            if(baseNewsDTO.UserId != 3) throw new ValidationException("User is not author","");

            News news = new News
            {
                Name = baseNewsDTO.Name,
                Title = baseNewsDTO.Title,
                Text = baseNewsDTO.Text,
                HeadingId = baseNewsDTO.HeadingId,
                UserId = baseNewsDTO.UserId,
                Status = status
            };

            List<Tag> tags = new List<Tag>();
            List<int> tagsId = new List<int>();

            if (baseNewsDTO.Tags != null)
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
            foreach(var tag in tags)
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

            Database.News.Create(news);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
