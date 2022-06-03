using System.Security.Claims;


namespace EasyToEnter.ASP.Tools
{
    public static class IdentityAssistant
    {
        public static string LastName(ClaimsPrincipal p) => p.FindFirst(x => x.Type == "LastName")?.Value?? string.Empty;



        public static string FirstName(ClaimsPrincipal p) => p.FindFirst(x => x.Type == "FirstName")?.Value ?? string.Empty;



        public static Guid? SessionId(ClaimsPrincipal p) 
        {
            if (p == null) return null;

            string ? sessionId = p.FindFirst(x => x.Type == "SessionId")?.Value;

            return sessionId == null ? null : new Guid(sessionId);
        }
    }
}