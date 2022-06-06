using EasyToEnter.ASP.Tools.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace EasyToEnter.ASP.HostBuilders
{
    public static class AuthenticationServices
    {
        public static IHostBuilder AddAuthenticationServices(this IHostBuilder host)
        {
            return host.ConfigureServices((context, services) =>
            {
                services.Configure<CookiePolicyOptions>(cookiePolicyOptions =>
                {
                    cookiePolicyOptions.CheckConsentNeeded = context => true;
                    cookiePolicyOptions.MinimumSameSitePolicy = SameSiteMode.Lax;
                });

                services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(configureOptions =>
                    {
                        // При требовании авторизации
                        configureOptions.LoginPath = new PathString("/Authentication/Login");

                        // При выходе с учетной записи
                        configureOptions.LogoutPath = new PathString("/Authentication/Logout");

                        // Доступ запрещен
                        configureOptions.AccessDeniedPath = new PathString("/Authentication/AccessDenied");

                        // сколько времени билет проверки подлинности, хранящийся в файле cookie
                        configureOptions.ExpireTimeSpan = TimeSpan.FromDays(36500);

                        // Срок жизни cookie
                        configureOptions.Cookie.MaxAge = TimeSpan.MaxValue;
                    });

                // Получает и проверяет сессию пользователя,
                services.AddScoped<SessionPerson>();
            });
        }
    }
}