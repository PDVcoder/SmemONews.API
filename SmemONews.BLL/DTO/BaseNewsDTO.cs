using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmemONews.BLL.DTO
{
    public class BaseNewsDTO
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int HeadingId { get; set; }
        public ICollection<String> Tags { get; set; }
    }
}
