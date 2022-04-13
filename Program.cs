using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Data.Initialization;

namespace EasyToEnter.ASP
{
    public class Program
    {
        public static void Main(string[] arguments)
        {
            IHost Host = CreateHostBuilder(arguments).Build();

            // Создание базы данных
            CreateDB(Host);

            Host.Run();
        }

        private static void CreateDB(IHost Host)
        {
            using IServiceScope ServiceScope = Host.Services.CreateScope();
            IServiceProvider ServiceProvider = ServiceScope.ServiceProvider;
            try
            {
                // Создание Context
                EasyToEnterDbContext Context = ServiceProvider.GetRequiredService<EasyToEnterDbContext>();

                // Инициализация базы данных
                InitializationDB.Initialize(Context);
            }
            catch (Exception Exception)
            {
                ILogger Logger = ServiceProvider.GetRequiredService<ILogger<Program>>();
                Logger.LogError(Exception, "Произошла ошибка при создании базы данных.");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] arguments) => Host.CreateDefaultBuilder(arguments).ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}