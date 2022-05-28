using EasyToEnter.ASP.Data;
using static EasyToEnter.ASP.Data.Initialization.Initialization;
using EasyToEnter.ASP.HostBuilders;

namespace EasyToEnter.ASP
{
    public class Program
    {
        public static void Main(string[] arguments)
        {
            IHost Host = CreateHostBuilder(arguments).Build();

            // Создание базы данных
            Initialize(Host);

            Host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] arguments)
        {
            return Host
                .CreateDefaultBuilder(arguments)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                .ConfigureDB();
        }
    }
}