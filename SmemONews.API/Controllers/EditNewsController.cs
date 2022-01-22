using Microsoft.AspNetCore.Mvc;
using SmemONews.BLL.DTO;
using SmemONews.BLL.Infrastructure;
using SmemONews.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmemONews.API.Controllers
{
    [Route("SmemONewsAPI/[controller]")]
    [ApiController]
    public class EditNewsController : ControllerBase
    {
        private readonly IEditNewsService _editNewsService;

        public EditNewsController(IEditNewsService editNewsService)
        {
            _editNewsService = editNewsService;
        }

        [HttpGet(nameof(GetOwnNews))]
        public IActionResult GetOwnNews(int? userId)
        {
            try
            {
                var result = _editNewsService.GetOwnNewsDTO(userId);
                return Ok(result);
            }
            catch (ValidationException e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }

        [HttpDelete(nameof(DeleteNews))]
        public IActionResult DeleteNews(int? newsId)
        {
            try
            {
                _editNewsService.Delete(newsId);
                return Ok($"News with id ({newsId} was deleted)");
            }
            catch (ValidationException e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }

        [HttpPut(nameof(DeleteNews))]
        public IActionResult DeleteNews(int? newsId, BaseNewsDTO baseNewsDTO)
        {
            try
            {
                _editNewsService.Update(baseNewsDTO, newsId);
                return Ok($"News with name ({baseNewsDTO.Name} was deleted)");
            }
            catch (ValidationException e)
            {
                return BadRequest($"Error: {e.Message}");
            }
        }
    }
}
