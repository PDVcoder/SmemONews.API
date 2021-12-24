

using System.Collections.Generic;

namespace SmemONews.BLL.DTO
{
    public class TagDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<NewsDTO> News { get; set; }
    }
}
