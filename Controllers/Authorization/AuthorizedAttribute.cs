using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EasyToEnter.ASP.Controllers.Authorization
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AuthorizedAttribute : SessionCheckAttribute, IAuthorizationFilter
    {
        public new void OnAuthorization(AuthorizationFilterContext authorizationFilterContext)
        {
            SessionPerson = authorizationFilterContext.HttpContext.RequestServices
                .GetRequiredService<SessionPerson>();

            if (!SessionPerson.IsAuthenticated)
                authorizationFilterContext.Result = new ChallengeResult(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}