using System.ComponentModel.DataAnnotations;

namespace Product_Management.src.Domain.Entities
{
        public class User
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [StringLength(100)]
            public string UserName { get; set; }

            [Required]
            public string PasswordHash { get; set; }

            [Required]
            [StringLength(20)]
            public string Role { get; set; } // Admin, User

            public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        }
    }

