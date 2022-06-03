using System.Security.Claims;


namespace EasyToEnter.ASP.Tools
{
    public static class IdentityAssistant
    {
        public static string LastName(ClaimsPrincipal p) => p.FindFirst(x => x.Type == "LastName")?.Value?? string.Empty;



        public static string FirstName(ClaimsPrincipal p) => p.FindFirst(x => x.Type == "FirstName")?.Value ?? string.Empty;



        public static string Id(ClaimsPrincipal p) => p.FindFirst(x => x.Type == "Id")?.Value ?? string.Empty;
    }
}