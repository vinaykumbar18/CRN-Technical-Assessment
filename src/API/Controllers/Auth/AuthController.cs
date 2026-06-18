using Microsoft.AspNetCore.Mvc;
using Product_Management.Application.DTOs;
using Product_Management.src.Application.DTOs.Auth;
using Product_Management.src.Application.Interfaces;

namespace Product_Management.src.API.Controllers.Auth
{
        [Route("api/[controller]")]
        [ApiController]
        public class AuthController : ControllerBase
        {
            private readonly IAuthService _authService;

            public AuthController(IAuthService authService)
            {
                _authService = authService;
            }

            // POST: api/auth/register
            [HttpPost("register")]
            public async Task<IActionResult> Register(RegisterDto dto)
            {
                var result = await _authService.RegisterAsync(dto);

                if (!result)
                {
                    return BadRequest("User already exists.");
                }

                return Ok("User registered successfully.");
            }

            // POST: api/auth/login
            [HttpPost("login")]
            public async Task<IActionResult> Login(LoginDto dto)
            {
                var token = await _authService.LoginAsync(dto);

                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized("Invalid username or password.");
                }

                return Ok(new
                {
                    Token = token
                });
            }
        }
    }

