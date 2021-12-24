using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmemONews.DAL.Entity
{
    public class Heading
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(16, ErrorMessage = "Heading name must be 16 characters or less")]
        public string Name { get; set; }

        public ICollection<News> News { get; set; }
    }
}
