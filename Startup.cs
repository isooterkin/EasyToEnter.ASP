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