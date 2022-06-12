using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

// https://stackoverflow.com/questions/31464359/how-do-you-create-a-custom-authorizeattribute-in-asp-net-core
// https://stackoverflow.com/questions/60943115/net-core-how-to-di-dbcontext-to-authrozationfilter
// https://translated.turbopages.org/proxy_u/en-ru.ru.7a3da30c-629a40f7-e8f59057-74722d776562/https/stackoverflow.com/questions/22955272/does-allowanonymous-override-authorizeattribute

// https://stackoverflow.com/questions/1064271/asp-net-mvc-set-custom-iidentity-or-iprincipal

namespace EasyToEnter.ASP.Tools.Authorization.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class SessionCheckAttribute : Attribute, IAuthorizationFilter
    {
        public SessionPerson? SessionPerson;

        public void OnAuthorization(AuthorizationFilterContext authorizationFilterContext)
        {
            SessionPerson = authorizationFilterContext.HttpContext.RequestServices
                .GetRequiredService<SessionPerson>();

            if (SessionPerson.Error == true)
                authorizationFilterContext.Result = new ChallengeResult(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}