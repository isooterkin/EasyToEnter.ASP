using EasyToEnter.ASP.Services.Discipline;
using EasyToEnter.ASP.Services.Favorites;
using EasyToEnter.ASP.Services.Vacancy;
using EasyToEnter.ASP.Services.Variability;

namespace EasyToEnter.ASP.HostBuilders
{
    public static class WebApiServices
    {
        public static IHostBuilder AddWebApiServices(this IHostBuilder host)
        {
            return host.ConfigureServices((context, services) =>
            {
                services.AddScoped<IDisciplineService, DisciplineService>();
                services.AddScoped<IVacancyService, VacancyService>();
                services.AddScoped<IVariabilityService, VariabilityService>();

                services.AddScoped<IVariabilityFavoritesService, VariabilityFavoritesService>();
                services.AddScoped<IUniversityFavoritesService, UniversityFavoritesService>();
                services.AddScoped<IVacancyFavoritesService, VacancyFavoritesService>();
            });
        }
    }
}