using System.ComponentModel.DataAnnotations;

namespace Product_Management.Application.DTOs
{
        public class LoginDto
        {
            [Required]
            public string UserName { get; set; }

            [Required]
            public string Password { get; set; }
        }
    }

