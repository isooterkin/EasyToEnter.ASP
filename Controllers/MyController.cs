using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.Tools;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasyToEnter.ASP.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace EasyToEnter.ASP.Controllers
{
    public class MyController: Controller
    {
        private protected readonly EasyToEnterDbContext _context;

        public MyController(EasyToEnterDbContext context) => _context = context;



        private protected async Task<bool> CheckSession()
        {
            Guid? sessionId = IdentityAssistant.SessionId(User);

            if (sessionId != null)
            {
                SessionModel? sessionModel = _context.Session.SingleOrDefault(s => s.Id == sessionId);

                if (sessionModel == null) await IncorrectSession();
                else if (sessionModel.LifeSpan < (int)((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds()) await LogoutSession();
                else return true;
            }

            return false;
        }



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



        private async Task IncorrectSession() => await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}