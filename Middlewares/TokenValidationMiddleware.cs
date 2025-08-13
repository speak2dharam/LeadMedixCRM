using LeadMedixCRM.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LeadMedixCRM.Middlewares
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IConfiguration _config;

        public TokenValidationMiddleware(RequestDelegate next, IServiceScopeFactory scopeFactory, IConfiguration config )
        {
            _next = next;
            _scopeFactory = scopeFactory;
            _config = config;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.ToString().ToLower();

            // Skip validation for public endpoints
            if (path.Contains("/auth/login") || path.Contains("/auth/add-user"))
            {
                await _next(context);
                return;
            }

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (string.IsNullOrWhiteSpace(token))
                throw new UnauthorizedAccessException("Missing token.");

            // ✅ JWT Signature & Expiry validation
            var handler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _config["Jwt:Issuer"],
                ValidAudience = _config["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])),
                ClockSkew = TimeSpan.Zero // No extra time buffer
            };

            ClaimsPrincipal principal;
            SecurityToken validatedToken;

            try
            {
                principal = handler.ValidateToken(token, validationParameters, out validatedToken);
            }
            catch (SecurityTokenExpiredException)
            {
                throw new UnauthorizedAccessException("Token expired.");
            }
            catch (SecurityTokenException ex)
            {
                throw new UnauthorizedAccessException($"Invalid token: {ex.Message}");
            }

            // ✅ DB check for revoked tokens
            var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                throw new UnauthorizedAccessException("Invalid token payload.");

            int userId = int.Parse(userIdClaim.Value);

            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var tokenInDb = dbContext.UserTokens.FirstOrDefault(t => t.Token == token && t.UserId == userId);
            if (tokenInDb == null || tokenInDb.IsRevoked)
                throw new UnauthorizedAccessException("Token revoked or not found.");

            // Proceed to next middleware
            await _next(context);
        }
    }
}
