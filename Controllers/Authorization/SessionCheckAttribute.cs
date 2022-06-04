﻿using Microsoft.AspNetCore.Mvc.Filters;

// https://stackoverflow.com/questions/31464359/how-do-you-create-a-custom-authorizeattribute-in-asp-net-core
// https://stackoverflow.com/questions/60943115/net-core-how-to-di-dbcontext-to-authrozationfilter
// https://translated.turbopages.org/proxy_u/en-ru.ru.7a3da30c-629a40f7-e8f59057-74722d776562/https/stackoverflow.com/questions/22955272/does-allowanonymous-override-authorizeattribute

namespace EasyToEnter.ASP.Controllers.Authorization
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class SessionCheckAttribute : Attribute, IAuthorizationFilter
    {
        public SessionPerson? SessionPerson;

        public void OnAuthorization(AuthorizationFilterContext authorizationFilterContext) 
            => SessionPerson = authorizationFilterContext.HttpContext.RequestServices
            .GetRequiredService<SessionPerson>();
    }
}