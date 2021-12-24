using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmemONews.DAL.Entity
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(16, ErrorMessage = "News name must be 16 characters or less")]
        public string Name { get; set; }

        [Required]
        [MaxLength(64, ErrorMessage = "News title must be 64 characters or less")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        [Required]
        public string Status { get; set; }

        public int HeadingId { get; set; }
        [ForeignKey("HeadingId")]
        public Heading Heading { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        
        public ICollection<Comment> Comments { get; set; }
        public ICollection<TagsInNews> NewsTags { get; set; }
    }
}
