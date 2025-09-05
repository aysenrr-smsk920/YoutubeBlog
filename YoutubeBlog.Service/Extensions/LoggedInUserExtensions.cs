using System.Security.Claims;

namespace YoutubeBlog.Service.Extensions
{
    public static class LoggedInUserExtensions
    {
        public static Guid GetLoggedUserId(this ClaimsPrincipal principal)
        {
            return Guid.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier));
        }
        public static string GetLoggedUserEmail(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Email);
        }
    }
}
