using Microsoft.AspNetCore.Mvc;
using SmemONews.BLL.BusinessModels;
using SmemONews.BLL.Infrastructure;
using SmemONews.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmemONews.API.Controllers
{
    public class NewsFilterController : Controller
    {
        private readonly INewsFilterService _newsFilterService;
        
        public NewsFilterController(INewsFilterService newsFilterService)
        {
            _newsFilterService = newsFilterService;
        }

        [HttpGet(nameof(GetAllNews))]
        public IActionResult GetAllNews()
        {
            var result = _newsFilterService.GetNews();
            return Ok(result);
        }

        [HttpGet(nameof(GetNewsByTag))]
        public IActionResult GetNewsByTag(string tag)
        {
            var result = _newsFilterService.GetNewsByTag(tag);
            return Ok(result);
        }

        [HttpGet(nameof(GetNewsByTitleOrName))]
        public IActionResult GetNewsByTitleOrName(string name)
        {
            var result = _newsFilterService.GetNewsByNameOrTitle(name);
            return Ok(result);
        }

        [HttpGet(nameof(GetNewsByDate))]
        public IActionResult GetNewsByDate(DateTime? firstDate, DateTime? secondDate)
        {
            try
            {
                var result = _newsFilterService.GetNewsByDateRange(firstDate, secondDate);
                return Ok(result);
            }
            catch(ValidationException e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }

        [HttpGet(nameof(GetNewsByHeadingId))]
        public IActionResult GetNewsByHeadingId(int? headingId)
        {
            try
            {
                var result = _newsFilterService.GetNewsByHeading(headingId);
                return Ok(result);
            }
            catch (ValidationException e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }

        //[HttpGet(nameof(GetNewsByFilter))]
        //public IActionResult GetNewsByFilter(NewsFilter newsFilter)
        //{
        //    try
        //    {
        //        var result = _newsFilterService.GetNewsByFilter(newsFilter);
        //        return Ok(result);
        //    }
        //    catch (ValidationException e)
        //    {
        //        return BadRequest($"Error: {e.Message}");
        //    }
        //}
    }
}
