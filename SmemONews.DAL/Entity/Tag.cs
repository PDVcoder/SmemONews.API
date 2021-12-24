using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmemONews.DAL.Entity
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(32, ErrorMessage = "Tag name must be 32 characters or less")]
        public string Name { get; set; }

        public ICollection<TagsInNews> NewsTags { get; set; }
    }
}
