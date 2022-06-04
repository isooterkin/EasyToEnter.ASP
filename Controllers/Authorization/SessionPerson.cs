using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Authorization
{
    public class SessionPerson
    {
        public readonly SessionModel? Session;
        public readonly PersonModel? Person;
        public readonly bool IsAuthenticated = false;

        public SessionPerson(EasyToEnterDbContext context, HttpContext? httpContext)
        {
            if (httpContext == null)
            {
                IsAuthenticated = false;
                return;
            }

            string? sessionId = httpContext.User.FindFirst(x => x.Type == "SessionId")?.Value;

            if (sessionId == null) IsAuthenticated = false;
            else
            {
                Session = context.Session.Include(s => s.PersonModel).SingleOrDefault(s => s.Id == new Guid(sessionId));

                if (Session == null)
                {
                    IsAuthenticated = false;

                    httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                }
                else
                {
                    if (Session.LifeSpan < (int)((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds())
                    {
                        IsAuthenticated = false;

                        context.Remove(Session);
                        context.SaveChanges();

                        httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    }
                    else
                    {
                        IsAuthenticated = true;
                        Person = Session.PersonModel;
                    }
                }
            }
        }
    }
}