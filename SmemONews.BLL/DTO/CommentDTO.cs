using System;

namespace SmemONews.BLL.DTO
{
    public class CommentDTO : BaseCommentDTO
    {
        public int Id { get; set; }
        public DateTime PublishDate { get; set; }
        public NewsDTO News { get; set; }
        public UserDTO User { get; set; }
    }
}