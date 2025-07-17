using LeadMedixCRM.DTOs;
using System.Security.Claims;

namespace LeadMedixCRM.Helpers
{
    public static class AuthClaimsHelper
    {
        public static AuthUser GetAuthUser(ClaimsPrincipal user)
        {
            return new AuthUser
            {
                UserId = int.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var id) ? id : 0,
                RoleId = int.TryParse(user.FindFirst(ClaimTypes.Role)?.Value, out var roleId) ? roleId : 0,
                FullName = user.FindFirst(ClaimTypes.Name)?.Value ?? "",
                Email = user.FindFirst(ClaimTypes.Email)?.Value ?? "",
            };
        }
    }
}
