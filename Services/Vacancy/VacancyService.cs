using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.Tools.Authorization;

namespace EasyToEnter.ASP.Services.Vacancy
{
    public class VacancyService : IVacancyService
    {
        private readonly EasyToEnterDbContext Context;
        private readonly IHttpContextAccessor HttpContextAccessor;



        public VacancyService(EasyToEnterDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            Context = context;
            HttpContextAccessor = httpContextAccessor;
        }



        public async Task<bool> DeleteVacancy(int vacancyId)
        {
            SessionPerson sessionPerson = new(Context, HttpContextAccessor);

            if (sessionPerson.IsAuthenticated == false) return false;

            try
            {
                VacancyModel? vacancy = Context.Vacancy
                    .SingleOrDefault(v => v.Id == vacancyId);

                if (vacancy == null) return true;

                Context.Vacancy.Remove(vacancy);
                await Context.SaveChangesAsync();
            }
            catch { return false; }

            return true;
        }



        public async Task<bool> DeleteVacancy(VacancyModel vacancy)
        {
            SessionPerson sessionPerson = new(Context, HttpContextAccessor);

            if (sessionPerson.IsAuthenticated == false) return false;

            try
            {
                Context.Vacancy.Remove(vacancy);
                await Context.SaveChangesAsync();
            }
            catch { return false; }

            return true;
        }
    }
}