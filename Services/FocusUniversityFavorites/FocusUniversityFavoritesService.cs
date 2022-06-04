using EasyToEnter.ASP.Models.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using EasyToEnter.ASP.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using EasyToEnter.ASP.Controllers.Authorization;

namespace EasyToEnter.ASP.Services.FocusUniversityFavorites
{
    public class FocusUniversityFavoritesService: IFocusUniversityFavoritesService
    {
        private readonly SessionPerson SessionPerson;
        private readonly EasyToEnterDbContext Context;



        public FocusUniversityFavoritesService(EasyToEnterDbContext context, SessionPerson sessionPerson)
        {
            Context = context;
            SessionPerson = sessionPerson;
        }
        

        //[Authorize]
        public async Task<bool> AddFavorites(int focusUniversityId)
        {
            if (SessionPerson.IsAuthenticated == false) return false;

            try
            {
                Context.FocusUniversityFavorites.Add(new FocusUniversityFavoritesModel()
                {
                    PersonId = SessionPerson.Person!.Id,
                    FocusUniversityId = focusUniversityId
                });

                await Context.SaveChangesAsync();
            }
            catch { return false; }

            return true;
        }



        public async Task<bool> DeleteFavorites(int focusUniversityId)
        {
            if (SessionPerson.IsAuthenticated == false) return false;

            try
            {
                FocusUniversityFavoritesModel? FocusUniversityFavorites = Context
                    .FocusUniversityFavorites
                    .SingleOrDefault(fuf => fuf.FocusUniversityId == focusUniversityId && fuf.PersonId == SessionPerson.Person!.Id);

                if (FocusUniversityFavorites == null) return true;

                Context.FocusUniversityFavorites.Remove(FocusUniversityFavorites);
                await Context.SaveChangesAsync();
            }
            catch { return false; }

            return true;
        }
    }
}