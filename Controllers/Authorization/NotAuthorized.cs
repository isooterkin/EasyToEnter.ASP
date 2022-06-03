using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace EasyToEnter.ASP.Controllers.Authorization
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NotAuthorized : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext authorizationFilterContext)
        {
            EasyToEnterDbContext context = authorizationFilterContext.HttpContext.RequestServices.GetRequiredService<EasyToEnterDbContext>();

            ClaimsPrincipal user = authorizationFilterContext.HttpContext.User;

            string? sessionIdString = user.FindFirst(x => x.Type == "SessionId")?.Value;

            if (sessionIdString != null)
            {
                Guid sessionId = new(sessionIdString);

                SessionModel? session = context.Session.SingleOrDefault(s => s.Id == sessionId);

                if (session != null)
                    if (session.LifeSpan > (int)((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds()) authorizationFilterContext.Result = new RedirectResult("/Home/Index");
                    else
                    {
                        context.Remove(session);
                        context.SaveChanges();

                        authorizationFilterContext.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    }
                else authorizationFilterContext.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }
    }
}