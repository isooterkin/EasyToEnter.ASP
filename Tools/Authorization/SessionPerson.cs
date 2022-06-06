using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Tools.Authorization
{
    public class SessionPerson
    {
        public readonly SessionModel? Session;
        public readonly PersonModel? Person;
        public readonly bool IsAuthenticated = false;
        public readonly bool Error = false;



        public SessionPerson(EasyToEnterDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext == null)
            {
                IsAuthenticated = false;
                return;
            }

            string? sessionId = httpContextAccessor.HttpContext.User
                .FindFirst(x => x.Type == "SessionId")?.Value;

            if (sessionId == null) IsAuthenticated = false;
            else
            {
                Session = context.Session.Include(s => s.PersonModel).SingleOrDefault(s => s.Id == new Guid(sessionId));

                if (Session == null)
                {
                    IsAuthenticated = false;

                    httpContextAccessor.HttpContext
                        .SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                    Error = true;
                }
                else
                {
                    if (Session.LifeSpan < (int)((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds())
                    {
                        IsAuthenticated = false;

                        context.Remove(Session);
                        context.SaveChanges();

                        httpContextAccessor.HttpContext
                            .SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                        Error = true;
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