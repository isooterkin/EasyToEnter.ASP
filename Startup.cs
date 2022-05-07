using EasyToEnter.ASP.Data;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // Строка подключения к БД
            void configureDbContext(DbContextOptionsBuilder o) => o.UseSqlServer(Configuration.GetConnectionString("MSSQL"));
            //void configureDbContext(DbContextOptionsBuilder o) => o.UseMySQL(Configuration.GetConnectionString("MYSQL"));

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
                endpoints.MapControllerRoute(
                    name: "default",
                    // Формат маршрутизации
                    // [Controller]/[ActionName]/[Parameters]
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}