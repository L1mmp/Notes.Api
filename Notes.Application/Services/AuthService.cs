using Microsoft.IdentityModel.Tokens;
using Notes.Domian.Models;
using Notes.Domian.Repositories.Interface;
using Notes.Domian.Services.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;

        public AuthService(IUserService userService)
        {
            _userService = userService;
        }

        public string Login(User user)
        {
            var _user = _userService
                .GetAllUsers()
                .FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);

            var secret = "secretTokenKey01";

            if (_user == null)
            {
                return "Can`t log in";
            }

            var token = GenerateJWTToken(secret, _user);

            return token;
        }

        public async Task<User> Register(User user)
        {
            var addedUser = await _userService.Add(user);
            return addedUser;
        }

        public string GenerateJWTToken(string secretKey, User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var _secretKey = Encoding.ASCII.GetBytes(secretKey);

            var descriptor = new SecurityTokenDescriptor
            {
                Audience = "",
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(_secretKey), SecurityAlgorithms.HmacSha256Signature)

            };

            SecurityToken token = tokenHandler.CreateToken(descriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
