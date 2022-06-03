﻿using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

// https://stackoverflow.com/questions/31464359/how-do-you-create-a-custom-authorizeattribute-in-asp-net-core
// https://stackoverflow.com/questions/60943115/net-core-how-to-di-dbcontext-to-authrozationfilter
// https://translated.turbopages.org/proxy_u/en-ru.ru.7a3da30c-629a40f7-e8f59057-74722d776562/https/stackoverflow.com/questions/22955272/does-allowanonymous-override-authorizeattribute

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

                if (session == null) authorizationFilterContext.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                else if (session.LifeSpan < (int)((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds())
                {
                    context.Remove(session);
                    context.SaveChanges();

                    authorizationFilterContext.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                }
            }
        }
    }
}