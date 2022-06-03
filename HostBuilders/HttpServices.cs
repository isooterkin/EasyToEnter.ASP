using System.Net.Http.Headers;

namespace EasyToEnter.ASP.HostBuilders
{
    public static class HttpServices
    {
        public static IHostBuilder AddHttpServices(this IHostBuilder host)
        {
            return host.ConfigureServices((context, services) =>
            {
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

                services.AddScoped(client =>
                {
                    HttpClient httpClient = new()
                    {
                        BaseAddress = new Uri(context.Configuration["HostName"])
                    };

                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    return httpClient;
                });
            });
        }
    }
}