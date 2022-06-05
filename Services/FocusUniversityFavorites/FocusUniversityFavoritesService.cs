using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Controllers.Authorization;

namespace EasyToEnter.ASP.Services.FocusUniversityFavorites
{
    public class FocusUniversityFavoritesService: IFocusUniversityFavoritesService
    {
        private readonly EasyToEnterDbContext Context;
        private readonly IHttpContextAccessor HttpContextAccessor;



        public FocusUniversityFavoritesService(EasyToEnterDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            Context = context;
            HttpContextAccessor = httpContextAccessor;
        }



        public async Task<bool> AddFavorites(int focusUniversityId)
        {
            SessionPerson SessionPerson = new (Context, HttpContextAccessor);
            
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
            SessionPerson SessionPerson = new(Context, HttpContextAccessor);

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