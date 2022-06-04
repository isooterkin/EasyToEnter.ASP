using EasyToEnter.ASP.Models.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using EasyToEnter.ASP.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Services.FocusUniversityFavorites
{
    public class FocusUniversityFavoritesService: IFocusUniversityFavoritesService
    {
        private readonly EasyToEnterDbContext Context;
        private readonly HttpContext? HttpContext;
        private readonly SessionModel? Session;

        public FocusUniversityFavoritesService(IHttpContextAccessor httpContextAccessor, EasyToEnterDbContext context)
        {
            Context = context;
            HttpContext = httpContextAccessor.HttpContext;
            Session = CheackSession();
        }



        private SessionModel? CheackSession()
        {
            if (HttpContext == null) return null;

            ClaimsPrincipal user = HttpContext.User;

            string? sessionIdString = user.FindFirst(x => x.Type == "SessionId")?.Value;

            if (sessionIdString == null) return null;

            Guid sessionId = new(sessionIdString);

            return Context.Session.SingleOrDefault(s => s.Id == sessionId);
        }



        public async Task<bool> AddFavorites(int focusUniversityId)
        {
            if (Session == null) return false;

            try
            {
                Context.FocusUniversityFavorites.Add(new FocusUniversityFavoritesModel()
                {
                    PersonId = Session.PersonId,
                    FocusUniversityId = focusUniversityId
                });

                await Context.SaveChangesAsync();
            }
            catch { return false; }

            return true;
        }



        public async Task<bool> DeleteFavorites(int focusUniversityId)
        {
            if (Session == null) return false;

            try
            {
                FocusUniversityFavoritesModel? FocusUniversityFavorites = Context
                    .FocusUniversityFavorites
                    .SingleOrDefault(fuf => fuf.FocusUniversityId == focusUniversityId && fuf.PersonId == Session.PersonId);

                if (FocusUniversityFavorites == null) return true;

                Context.FocusUniversityFavorites.Remove(FocusUniversityFavorites);
                await Context.SaveChangesAsync();
            }
            catch { return false; }

            return true;
        }
    }
}