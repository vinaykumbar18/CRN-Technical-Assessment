using System.ComponentModel.DataAnnotations;

namespace Product_Management.src.Application.DTOs.Auth
{
        public class RegisterDto
        {
            [Required]
            [StringLength(100)]
            public string UserName { get; set; }

            [Required]
            [MinLength(6)]
            public string Password { get; set; }

            [Required]
            public string Role { get; set; } // Admin or User
        }
    }

