using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Tools.Authorization;

namespace EasyToEnter.ASP.Services.Favorites
{
    public class VacancyFavoritesService: IVacancyFavoritesService
    {
        private readonly EasyToEnterDbContext Context;
        private readonly IHttpContextAccessor HttpContextAccessor;



        public VacancyFavoritesService(EasyToEnterDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            Context = context;
            HttpContextAccessor = httpContextAccessor;
        }



        public async Task<bool> AddFavorites(VacancyModel vacancy)
        {
            SessionPerson sessionPerson = new(Context, HttpContextAccessor);

            if (sessionPerson.IsAuthenticated == false) return false;

            try
            {
                Context.VacancyFavorites.Add(new VacancyFavoritesModel()
                {
                    PersonId = sessionPerson.Person!.Id,
                    VacancyId = vacancy.Id
                });

                await Context.SaveChangesAsync();
            }
            catch { return false; }

            return true;
        }



        public async Task<bool> DeleteFavorites(VacancyModel vacancy)
        {
            SessionPerson sessionPerson = new(Context, HttpContextAccessor);

            if (sessionPerson.IsAuthenticated == false) return false;

            try
            {
                VacancyFavoritesModel? vacancyFavorites = Context
                    .VacancyFavorites
                    .SingleOrDefault(vf => vf.VacancyId == vacancy.Id && vf.PersonId == sessionPerson.Person!.Id);

                if (vacancyFavorites == null) return true;

                Context.VacancyFavorites.Remove(vacancyFavorites);
                await Context.SaveChangesAsync();
            }
            catch { return false; }

            return true;
        }
    }
}