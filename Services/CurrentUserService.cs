using LeadMedixCRM.Interfaces;
using System.Security.Claims;

namespace LeadMedixCRM.Services
{
    public class CurrentUserService:ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }

        public int GetUserId()
        {
            var userIdClaim = _httpContextAccessor.HttpContext.User
            .FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return userIdClaim != null ? int.Parse(userIdClaim) : 0;
        }

        public string GetUserRole()
        {
            return _httpContextAccessor.HttpContext.User
            .FindFirst(ClaimTypes.Role)?.Value ?? string.Empty;
        }
    }
}
