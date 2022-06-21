using EasyToEnter.ASP.Services.Discipline;
using EasyToEnter.ASP.Services.UniversityFavorites;
using EasyToEnter.ASP.Services.Vacancy;
using EasyToEnter.ASP.Services.Variability;
using EasyToEnter.ASP.Services.VariabilityFavorites;

namespace EasyToEnter.ASP.HostBuilders
{
    public static class WebApiServices
    {
        public static IHostBuilder AddWebApiServices(this IHostBuilder host)
        {
            return host.ConfigureServices((context, services) =>
            {
                services.AddScoped<IDisciplineService, DisciplineService>();
                services.AddScoped<IVariabilityFavoritesService, VariabilityFavoritesService>();
                services.AddScoped<IVacancyService, VacancyService>();
                services.AddScoped<IVariabilityService, VariabilityService>();
                services.AddScoped<IUniversityFavoritesService, UniversityFavoritesService>();
            });
        }
    }
}