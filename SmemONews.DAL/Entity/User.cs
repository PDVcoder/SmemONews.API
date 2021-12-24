using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmemONews.DAL.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(24, ErrorMessage = "User firstname must be 24 or less")]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(24, ErrorMessage = "User lastname must be 24 or less")]
        public string Lastname { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }

        [Required]
        [MaxLength(13, ErrorMessage = "User phone number must be 13 characters or less")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(32, ErrorMessage = "User email must be 32 charaacters or less")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = "User password hash must be 128 or less")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        [Required]
        [MaxLength(16, ErrorMessage = "User login must 16 characters or less")]
        public string Login { get; set; }

        [Required]
        [MaxLength(16, ErrorMessage = "User status must be 16 characters or less")]
        public string Status { get; set; }

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        public ICollection<News> News { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
