using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.Tools;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers
{
    public class MyController: Controller
    {
        private protected readonly EasyToEnterDbContext _context;
        public MyController(EasyToEnterDbContext context)
        {
            _context = context;

            Guid? sessionId = IdentityAssistant.SessionId(User);

            if (sessionId != null && _context.Session.SingleOrDefault(s => s.Id == sessionId) == null) _ = IncorrectSession();
        }



        private async Task IncorrectSession() => await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);



        private protected async Task LogoutSession() 
        {
            Guid? sessionId = IdentityAssistant.SessionId(User);

            if (sessionId == null) return;

            SessionModel? Session = await _context.Session.SingleOrDefaultAsync(s => s.Id == sessionId);

            if (Session != null)
            {
                _context.Remove(Session);
                await _context.SaveChangesAsync();
            }

            await IncorrectSession();
        }



        private protected bool CheckIdentity() => User != null && User.Identity != null && User.Identity.IsAuthenticated == true;
    }
}