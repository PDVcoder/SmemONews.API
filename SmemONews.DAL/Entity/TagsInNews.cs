using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmemONews.DAL.Entity
{
    public class TagsInNews
    {
        [Key]
        public int Id { get; set; }
        
        public int NewsId { get; set; }
        [ForeignKey("NewsId")]
        public News News { get; set; }

       
        public int TagId { get; set; }
        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}
