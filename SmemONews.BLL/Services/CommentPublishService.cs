using SmemONews.BLL.DTO;
using SmemONews.BLL.Interfaces;
using SmemONews.DAL.Entity;
using SmemONews.DAL.Interfaces;

namespace SmemONews.BLL.Services
{
    public class CommentPublishService : ICommentPublishService
    {
        private IUnitOfWork Database;
        public CommentPublishService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void PublishComment(BaseCommentDTO commentDTO)
        {
            Comment comment = new Comment
            {
                Text = commentDTO.Text,
                Mark = commentDTO.Mark,
                UserId = commentDTO.UserId,
                NewsId = commentDTO.NewsId
            };

            Database.Comment.Create(comment);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
