using Microsoft.IdentityModel.Tokens;
using RetailApp.Application.Helper;
using RetailApp.Application.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace RetailApp.Api.MiddleWare
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;

        public JwtMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;            
            _config = config;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
                await InitializeUserToContext(context, userService,token);
            await _next(context);
        }

        private async Task InitializeUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config.GetSection("JwtSettings").GetSection("JwtKey").Value);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    //ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var merchantId = jwtToken.Claims.First(x => x.Type == "useremail").Value.ToString();
                var apiKey = jwtToken.Claims.First(x => x.Type == "password").Value.ToString();

                context.Items["User"] = await userService.GetUser(merchantId, apiKey);
            }
            catch
            {
                throw new SecurityTokenExpiredException();
            }
        }

    }
}
