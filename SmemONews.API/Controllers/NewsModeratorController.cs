using Microsoft.AspNetCore.Mvc;
using SmemONews.BLL.Infrastructure;
using SmemONews.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmemONews.API.Controllers
{
    public class NewsModeratorController : Controller
    {
        private readonly INewsModeratorService _newsModeratorService;

        public NewsModeratorController(INewsModeratorService newsModeratorService)
        {
            _newsModeratorService = newsModeratorService;
        }

        [HttpGet(nameof(GetNewsForCheck))]
        public IActionResult GetNewsForCheck()
        {
            var news = _newsModeratorService.GetNewsForCheck();
            return Ok(news);
        }

        [HttpPut(nameof(ChangeNewsStatus))]
        public IActionResult ChangeNewsStatus(int? newsId, string status)
        {
            string result = $"Status changed by {status.ToUpper()} in News with id: {newsId} ";
            try
            {
                _newsModeratorService.PublishNews(newsId, status);
            }
            catch (ValidationException e)
            {
                result = $"Error: {e.Message}";
            }
            return Ok(result);
        }
    }
}
