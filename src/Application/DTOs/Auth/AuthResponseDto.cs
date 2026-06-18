namespace Product_Management.src.Application.DTOs.Auth
{
        public class AuthResponseDto
        {
            public string Token { get; set; }

            public DateTime ExpiresAt { get; set; }

            public string UserName { get; set; }

            public string Role { get; set; }
        }
    }

