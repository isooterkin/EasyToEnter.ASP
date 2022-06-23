using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EasyToEnter.ASP.Tools.Authorization.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AdministratorRoleAttribute: SessionCheckAttribute, IAuthorizationFilter
    {
        public new void OnAuthorization(AuthorizationFilterContext authorizationFilterContext)
        {
            SessionPerson = authorizationFilterContext.HttpContext.RequestServices
                .GetRequiredService<SessionPerson>();
            
            if (!SessionPerson.IsAuthenticated)
                authorizationFilterContext.Result = new ChallengeResult(CookieAuthenticationDefaults.AuthenticationScheme);

            if (SessionPerson.IsAuthenticated == true && SessionPerson.Person!.RoleId != 1)
                authorizationFilterContext.Result = new ForbidResult();
        }
    }
}