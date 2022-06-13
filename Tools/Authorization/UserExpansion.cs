using System.Security.Claims;

namespace EasyToEnter.ASP.Tools.Authorization
{
    public static class IdentityAssistant
    {
        public static int? Id(this ClaimsPrincipal user)
        {
            string? stringId = user.FindFirst(x => x.Type == "Id")?.Value;
            return stringId == null ? null : int.Parse(stringId);
        }



        public static string Login(this ClaimsPrincipal user)
            => user.FindFirst(x => x.Type == "Login")?.Value ?? string.Empty;



        public static string Role(this ClaimsPrincipal user)
            => user.FindFirst(x => x.Type == "Role")?.Value ?? string.Empty;



        public static Guid? SessionId(this ClaimsPrincipal user)
        {
            string? sessionId = user.FindFirst(x => x.Type == "SessionId")?.Value;
            return sessionId == null ? null : new Guid(sessionId);
        }
    }
}