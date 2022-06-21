using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Tools.Authorization;

namespace EasyToEnter.ASP.Services.UniversityFavorites
{
    public class UniversityFavoritesService: IUniversityFavoritesService
    {
        private readonly EasyToEnterDbContext Context;
        private readonly IHttpContextAccessor HttpContextAccessor;



        public UniversityFavoritesService(EasyToEnterDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            Context = context;
            HttpContextAccessor = httpContextAccessor;
        }



        public async Task<bool> AddFavorites(int universityId)
        {
            SessionPerson sessionPerson = new(Context, HttpContextAccessor);

            if (sessionPerson.IsAuthenticated == false) return false;

            try
            {
                Context.UniversityFavorites.Add(new UniversityFavoritesModel()
                {
                    PersonId = sessionPerson.Person!.Id,
                    UniversityId = universityId
                });

                await Context.SaveChangesAsync();
            }
            catch { return false; }

            return true;
        }



        public async Task<bool> DeleteFavorites(int universityId)
        {
            SessionPerson sessionPerson = new(Context, HttpContextAccessor);

            if (sessionPerson.IsAuthenticated == false) return false;

            try
            {
                UniversityFavoritesModel? universityFavorites = Context
                    .UniversityFavorites
                    .SingleOrDefault(fuf => fuf.UniversityId == universityId && fuf.PersonId == sessionPerson.Person!.Id);

                if (universityFavorites == null) return true;

                Context.UniversityFavorites.Remove(universityFavorites);
                await Context.SaveChangesAsync();
            }
            catch { return false; }

            return true;
        }
    }
}