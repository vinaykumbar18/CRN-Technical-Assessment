using Product_Management.Application.DTOs;
using Product_Management.src.Application.DTOs.Auth;

namespace Product_Management.src.Application.Interfaces
{
        public interface IAuthService
        {
            Task<bool> RegisterAsync(RegisterDto dto);

            Task<string?> LoginAsync(LoginDto dto);
        }
    }

