using Microsoft.AspNetCore.Mvc;
using SmemONews.BLL.Infrastructure;
using SmemONews.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmemONews.API.Controllers
{
    public class NewsViewController : Controller
    {
        private readonly INewsViewService _newsViewService;

        public NewsViewController(INewsViewService newsViewService)
        {
            _newsViewService = newsViewService;
        }

        [HttpGet(nameof(GetComments))]
        public IActionResult GetComments(int? newsId)
        {
            try
            {
                var result = _newsViewService.GetComments(newsId);
                return Ok(result);
            }
            catch (ValidationException e)
            {
                return Ok($"Error: {e.Message}");
            }
        }

        [HttpGet(nameof(GetNews))]
        public IActionResult GetNews(int? newsId)
        {
            try
            {
                var result = _newsViewService.GetNews(newsId);
                return Ok(result);
            }
            catch (ValidationException e)
            {
                return Ok($"Error: {e.Message}");
            }
        }

    }
}
