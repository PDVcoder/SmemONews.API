using Microsoft.AspNetCore.Mvc;
using SmemONews.BLL.DTO;
using SmemONews.BLL.Infrastructure;
using SmemONews.BLL.Interfaces;

namespace SmemONews.API.Controllers
{
    public class NewsPublishController : Controller
    {
        private readonly INewsPublishService _newsPublishService;

        public NewsPublishController(INewsPublishService newsPublishService)
        {
            _newsPublishService = newsPublishService;
        }
        
        [HttpGet(nameof(GetHeadings))]
        public IActionResult GetHeadings()
        {
            var headings = _newsPublishService.GetHeadings();
            return Ok(headings);
        }

        [HttpPost(nameof(PublishNews))]
        public IActionResult PublishNews(BaseNewsDTO news)
        {
            string result = "An application for publication has been submitted";
            try
            {
                _newsPublishService.PublishNews(news);
            }
            catch (ValidationException e)
            {
                result = $"Error: {e.Message}";
            }
            return Ok(result);
        }
    }
}
