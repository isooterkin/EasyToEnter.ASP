using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Controllers.Authorization;

namespace EasyToEnter.ASP.Services.VariabilityFavorites
{
    public class VariabilityFavoritesService : IVariabilityFavoritesService
    {
        private readonly EasyToEnterDbContext Context;
        private readonly IHttpContextAccessor HttpContextAccessor;



        public VariabilityFavoritesService(EasyToEnterDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            Context = context;
            HttpContextAccessor = httpContextAccessor;
        }



        public async Task<bool> AddFavorites(int variabilityId)
        {
            SessionPerson sessionPerson = new(Context, HttpContextAccessor);

            if (sessionPerson.IsAuthenticated == false) return false;

            try
            {
                Context.VariabilityFavorites.Add(new VariabilityFavoritesModel()
                {
                    PersonId = sessionPerson.Person!.Id,
                    VariabilityId = variabilityId
                });

                await Context.SaveChangesAsync();
            }
            catch { return false; }

            return true;
        }



        public async Task<bool> DeleteFavorites(int variabilityId)
        {
            SessionPerson sessionPerson = new(Context, HttpContextAccessor);

            if (sessionPerson.IsAuthenticated == false) return false;

            try
            {
                VariabilityFavoritesModel? variabilityFavorites = Context
                    .VariabilityFavorites
                    .SingleOrDefault(fuf => fuf.VariabilityId == variabilityId && fuf.PersonId == sessionPerson.Person!.Id);

                if (variabilityFavorites == null) return true;

                Context.VariabilityFavorites.Remove(variabilityFavorites);
                await Context.SaveChangesAsync();
            }
            catch { return false; }

            return true;
        }
    }
}