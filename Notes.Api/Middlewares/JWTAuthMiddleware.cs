using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Api.Middlewares
{
    public class JWTAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public JWTAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var authHeader = context.Request.Headers["Authorization"]
                .FirstOrDefault();

            if (authHeader != null)
            {
                var secret = "secret secret secret secret secret";
                var key = Encoding.UTF8.GetBytes(secret);

                var token = authHeader.Split(" ").Last();


                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenValidationParams = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key),

                };

                tokenHandler.ValidateToken(token
                    ,tokenValidationParams
                    , out var securityToken);

            }

           return _next.Invoke(context);
        }

    }
}
