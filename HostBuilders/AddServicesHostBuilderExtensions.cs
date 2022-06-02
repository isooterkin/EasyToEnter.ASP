using EasyToEnter.ASP.Services.Discipline;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host) 
        {
            host.ConfigureServices((context, services) =>
            {
                //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                //    .AddJwtBearer(configureOptions =>
                //    {
                //        configureOptions.TokenValidationParameters = new TokenValidationParameters
                //        {
                //            ValidateIssuer = true,
                //            ValidateAudience = true,
                //            ValidateLifetime = true,
                //            ValidateIssuerSigningKey = true,
                //            ValidIssuer = context.Configuration["JWT:Issuer"],
                //            ValidAudience = context.Configuration["JWT:Audience"],
                //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(context.Configuration["JWT:Key"]))
                //        };
                //    });

                services.Configure<CookiePolicyOptions>(cookiePolicyOptions =>
                {
                    cookiePolicyOptions.CheckConsentNeeded = context => true;
                    cookiePolicyOptions.MinimumSameSitePolicy = SameSiteMode.Lax;
                });

                JsonConvert.DefaultSettings = () => new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

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
                        configureOptions.ExpireTimeSpan = TimeSpan.FromSeconds(1110);
                    });

                services.AddControllersWithViews();

                services.AddServerSideBlazor();

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


                // Problem: https://stackoverflow.com/questions/60311852/error-connection-disconnected-with-error-error-server-returned-an-error-on-cl
                services.AddSignalR(e => {
                    e.MaximumReceiveMessageSize = 102400000;
                });
            });

            return host;
        }
    }
}