using BCrypt.Net;
using Dev4Side_sheshan.DTOs;
using Dev4Side_sheshan.Models;
using Dev4Side_sheshan.Repos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dev4Side_sheshan.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepo _userRepo;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepo userRepo, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _configuration = configuration;
        }

        private string GenerateJWTtoken(UserEntity user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer : _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims : claims,
                expires : DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }









        //Implementations below.
        public async Task<string> LoginAsync(UserLoginDTO userLoginDTO)
        {
            var existingUser = await _userRepo.getUserName(userLoginDTO.Email);
            if (existingUser == null || !BCrypt.Net.BCrypt.Verify(userLoginDTO.Password, existingUser.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }
            return GenerateJWTtoken(existingUser);
        }

       

        public async Task RegisterAsync(UserRegisterDTO userRegisterDTO)
        {
            var existingUser = await _userRepo.getUserName(userRegisterDTO.Email);
            if (existingUser != null)
            {
                throw new Exception($"User Already exist with email {userRegisterDTO.Email}");
            }
            var hashPW = BCrypt.Net.BCrypt.HashPassword(userRegisterDTO.Password);
            var user = new UserEntity
            {
                Email = userRegisterDTO.Email,
                PasswordHash = hashPW
            };
            await _userRepo.createAsync(user);
        }
    }
}
