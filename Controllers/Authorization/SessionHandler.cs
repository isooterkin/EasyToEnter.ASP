using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace EasyToEnter.ASP.Controllers.Authorization
{
    public class SessionHandler :AuthorizationHandler<SessionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SessionRequirement requirement)
        {


            return Task.CompletedTask;
        }
    }
}