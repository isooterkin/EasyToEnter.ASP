using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.Tools;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace EasyToEnter.ASP.Controllers.Authorization
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SessionCheckAttribute : Attribute, IAuthorizationFilter
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

                if (session == null)
                {
                    authorizationFilterContext.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                }
                else
                {
                    if (session.LifeSpan < (int)((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds())
                    {

                        context.Remove(session);
                        context.SaveChanges();

                        authorizationFilterContext.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    }
                    else
                    {
                        // ret
                    }
                }
            }




            ////check access 
            //if (CheckPermissions())
            //{
            //    //all good, add some code if you want. Or don't
            //}
            //else
            //{
            //    //DENIED!
            //    //return "ChallengeResult" to redirect to login page (for example)
            //    context.Result = new ChallengeResult(CookieAuthenticationDefaults.AuthenticationScheme);
            //}
        }
    }
}