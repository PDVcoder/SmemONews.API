using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmemONews.DAL.Entity
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(10, ErrorMessage ="Role name must be 10 characters or less")]
        public string Name { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = "Role description must be 128 characters or less")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
