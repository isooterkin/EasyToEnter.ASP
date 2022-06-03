using EasyToEnter.ASP.Services.Discipline;

namespace EasyToEnter.ASP.HostBuilders
{
    public static class WebApiServices
    {
        public static IHostBuilder AddWebApiServices(this IHostBuilder host)
        {
            return host.ConfigureServices((context, services) =>
            {
                services.AddScoped<IDisciplineService, DisciplineService>();
            });
        }
    }
}