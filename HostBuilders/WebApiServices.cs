using EasyToEnter.ASP.Services.Discipline;
using EasyToEnter.ASP.Services.FocusUniversityFavorites;

namespace EasyToEnter.ASP.HostBuilders
{
    public static class WebApiServices
    {
        public static IHostBuilder AddWebApiServices(this IHostBuilder host)
        {
            return host.ConfigureServices((context, services) =>
            {
                services.AddScoped<IDisciplineService, DisciplineService>();
                services.AddScoped<IFocusUniversityFavoritesService, FocusUniversityFavoritesService>();
            });
        }
    }
}