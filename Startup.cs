using EasyToEnter.ASP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EasyToEnter.ASP
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // Конфигурация БД
            void configureDbContext(DbContextOptionsBuilder o)
            {
                // Строка подключения к БД
                //o.UseSqlServer(Configuration.GetConnectionString("MSSQL"));
                //o.UseMySQL(Configuration.GetConnectionString("MYSQL"));
                o.UseNpgsql(Configuration.GetConnectionString("PGSQL"));

                // Убрать предупреждение о большом количестве Include
                o.ConfigureWarnings(x => x.Ignore(RelationalEventId.MultipleCollectionIncludeWarning));
            }

            // Регистрация контекста БД
            services.AddDbContextPool<EasyToEnterDbContext>(configureDbContext);

            // Регистрация завода контекста БД
            services.AddSingleton(new EasyToEnterDbContextFactory(configureDbContext));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // Значение HSTS по умолчанию составляет 30 дней.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            // добавляем поддержку статических файлов
            app.UseStaticFiles();

            // добавляем возможности маршрутизации
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "Applicant",
                //    pattern: "Applicant/{controller}/{action}/{id?}",
                //    defaults: new
                //    {
                //        controller = "Applicant",
                //        action = "LevelSelection"
                //    });

                // Формат маршрутизации
                // [Controller]/[ActionName]/[Parameters]
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}",
                    defaults: new
                    {
                        controller = "Home",
                        action = "Index"
                    });
            });
        }
    }
}