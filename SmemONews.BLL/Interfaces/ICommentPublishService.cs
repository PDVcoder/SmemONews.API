using SmemONews.BLL.DTO;

namespace SmemONews.BLL.Interfaces
{
    public interface ICommentPublishService
    {
        void PublishComment(BaseCommentDTO commentDTO);
        void Dispose();
    }
}
