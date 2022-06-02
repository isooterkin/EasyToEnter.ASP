using EasyToEnter.ASP.Services.Discipline;
using System.Net.Http.Headers;

namespace EasyToEnter.ASP.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host) 
        {
            host.ConfigureServices((context, services) =>
            {
                services.AddServerSideBlazor();
                services.AddControllersWithViews();

                // services.AddRazorPages();

                services.AddScoped(client =>
                {
                    HttpClient httpClient = new()
                    {
                        BaseAddress = new Uri(context.Configuration["HostName"])
                    };

                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    return httpClient;
                });

                services.AddScoped<IDisciplineService, DisciplineService>();
            });

            return host;
        }
    }
}