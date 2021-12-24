using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmemONews.BLL.DTO
{
    public class NewsDTO : BaseNewsDTO
    {
        public int Id { get; set; }
        //public string Name { get; set; }
        //public string Title { get; set; }
        //public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        //public int UserId { get; set; }
        public UserDTO User { get; set; }
        //public int HeadingId { get; set; }
        public HeadingDTO Headnig { get; set; }
        //public ICollection<TagDTO> Tags{ get; set; }
    }
}
