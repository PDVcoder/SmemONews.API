using AutoMapper;
using SmemONews.BLL.DTO;
using SmemONews.BLL.Infrastructure;
using SmemONews.BLL.Interfaces;
using SmemONews.DAL.Entity;
using SmemONews.DAL.Interfaces;
using System.Collections.Generic;

namespace SmemONews.BLL.Services
{
    public class NewsViewService : INewsViewService
    {
        private IUnitOfWork Database;
        public NewsViewService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public ICollection<CommentDTO> GetComments(int? newsId)
        {
            if (newsId == null) throw new ValidationException("NewsId is null","");

            var mapper = new MapperConfiguration(config => config.CreateMap<Comment, CommentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(Database.Comment.FindWithIncludes(e => e.NewsId == newsId));
        }

        public NewsDTO GetNews(int? newsId)
        {
            if (newsId == null) throw new ValidationException("NewsId is null", "");
            News news = Database.News.Get(newsId.Value);
            if (news == null) throw new ValidationException("News is null", "");

            UserDTO user = GetUser(news.UserId);
            HeadingDTO heading = GetHeading(news.HeadingId);

            return new NewsDTO
            {
                Id = news.Id,
                Name = news.Name,
                Title = news.Title,
                Text = news.Text,
                PublishDate = news.PublishDate,
                UserId = news.UserId,
                HeadingId = news.HeadingId,
                User = user,
                Headnig = heading
            };
        }

        private UserDTO GetUser(int? userId)
        {
            if (userId == null) throw new ValidationException("UserId is null", "");
            User user = Database.User.Get(userId.Value);
            if(user == null) throw new ValidationException("User is null", "");

            Role role = Database.Role.Get(user.RoleId);
            if(role == null) throw new ValidationException("Role is null", "");

            return new UserDTO
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Login = user.Login,
                RegistrationDate = user.RegistrationDate,
                Birthday = user.Birthday,
                RoleId = user.RoleId,
                Role = new RoleDTO
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description
                }
            };
        }

        private HeadingDTO GetHeading(int? headingId)
        {
            if (headingId == null) throw new ValidationException("Heading id is null", "");
            Heading heading = Database.Heading.Get(headingId.Value);
            if (heading == null) throw new ValidationException("Heading is null", "");

            return new HeadingDTO
            {
                Id = heading.Id,
                Name = heading.Name
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
