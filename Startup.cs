using Microsoft.AspNetCore.Localization;

namespace EasyToEnter.ASP
{
    public class Startup
    {
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

            app.UseRequestLocalization(options => options
                .AddSupportedCultures(new string[] { "en-GB", "en-US" })
                .AddSupportedUICultures(new string[] { "en-GB", "en-US" })
                .SetDefaultCulture("en-GB")
                .RequestCultureProviders
                .Insert(0, new CustomRequestCultureProvider(context => Task.FromResult(new ProviderCultureResult("en-GB"))!)));

            // добавляем поддержку статических файлов
            app.UseStaticFiles();

            // добавляем возможности маршрутизации
            app.UseRouting();

            app.UseCookiePolicy();

            app.UseSession();

            // 
            app.UseAuthentication();

            // 
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();

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