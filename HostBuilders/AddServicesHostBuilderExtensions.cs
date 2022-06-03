using EasyToEnter.ASP.Services.Discipline;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using System.Text;
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
                //JsonConvert.DefaultSettings = () => new JsonSerializerSettings
                //{
                //    Formatting = Formatting.Indented,
                //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                //    ContractResolver = new CamelCasePropertyNamesContractResolver()
                //};

                services.Configure<CookiePolicyOptions>(cookiePolicyOptions =>
                {
                    cookiePolicyOptions.CheckConsentNeeded = context => true;
                    cookiePolicyOptions.MinimumSameSitePolicy = SameSiteMode.None;
                });
                services.AddDistributedMemoryCache();
                services.AddSession();
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
                    //.AddJwtBearer(configureOptions =>
                    //{
                    //    configureOptions.TokenValidationParameters = new TokenValidationParameters
                    //    {
                    //        // укзывает, будет ли валидироваться издатель при валидации токена
                    //        ValidateIssuer = true,
                    //        ValidIssuer = context.Configuration["JWT:Issuer"],

                    //        // будет ли валидироваться потребитель токена
                    //        ValidateAudience = true,
                    //        ValidAudience = context.Configuration["JWT:Audience"],

                    //        // валидация ключа безопасности
                    //        ValidateIssuerSigningKey = true,
                    //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(context.Configuration["JWT:Key"])),
                            
                    //        // будет ли валидироваться время существования
                    //        ValidateLifetime = true
                    //    };
                    //});

                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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