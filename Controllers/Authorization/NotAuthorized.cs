using EasyToEnter.ASP.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EasyToEnter.ASP.Controllers.Authorization
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NotAuthorized : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext authorizationFilterContext)
        {
            EasyToEnterDbContext context = authorizationFilterContext.HttpContext.RequestServices.GetRequiredService<EasyToEnterDbContext>();

            SessionPerson sessionPerson = new(context, authorizationFilterContext.HttpContext);
            
            if (sessionPerson.IsAuthenticated == true)
                authorizationFilterContext.Result = new RedirectResult("/Home/Index");
        }
    }
}