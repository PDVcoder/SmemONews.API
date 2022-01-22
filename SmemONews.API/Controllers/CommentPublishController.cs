using Microsoft.AspNetCore.Mvc;
using SmemONews.BLL.DTO;
using SmemONews.BLL.Infrastructure;
using SmemONews.BLL.Interfaces;

namespace SmemONews.API.Controllers
{
    [Route("SmemONewsAPI/[controller]")]
    [ApiController]
    public class CommentPublishController : ControllerBase
    {
        private readonly ICommentPublishService _commentPublishService;

        public CommentPublishController(ICommentPublishService commentPublishService)
        {
            _commentPublishService = commentPublishService;
        }

        [HttpPost(nameof(PublishComment))]
        public IActionResult PublishComment(BaseCommentDTO comment)
        {
            string result = $"Comment add succsesful to news with ID({comment.NewsId}) from user with ID({comment.UserId})";
            try
            {
                _commentPublishService.PublishComment(comment);
            }
            catch (ValidationException e)
            {
                result = $"Error: {e.Message}";
                throw;
            }
            return Ok(result);
        }
    }
}
