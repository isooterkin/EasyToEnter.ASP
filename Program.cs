using EasyToEnter.ASP.HostBuilders;

namespace EasyToEnter.ASP
{
    public class Program
    {
        public static void Main(string[] arguments) => Host
            .CreateDefaultBuilder(arguments)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
            .AddAuthenticationServices()
            .AddHttpServices()
            .AddDatabaseServices()
            .AddWebApiServices()
            .AddOthersServices()
            .Build()
            .AddDatabaseInitialization()
            .Run();
    }
}