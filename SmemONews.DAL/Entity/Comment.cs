using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmemONews.DAL.Entity
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        
        [Required]
        public int  Mark { get; set; }
        public int NewsId { get; set; }
        [ForeignKey("NewsId")]
        public News News { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
