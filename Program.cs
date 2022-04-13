using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Data.Initialization;

namespace EasyToEnter.ASP
{
    public class Program
    {
        public static void Main(string[] arguments)
        {
            IHost Host = CreateHostBuilder(arguments).Build();

            // �������� ���� ������
            CreateDB(Host);

            Host.Run();
        }

        private static void CreateDB(IHost Host)
        {
            using IServiceScope ServiceScope = Host.Services.CreateScope();
            IServiceProvider ServiceProvider = ServiceScope.ServiceProvider;
            try
            {
                // �������� Context
                EasyToEnterDbContext Context = ServiceProvider.GetRequiredService<EasyToEnterDbContext>();

                // ������������� ���� ������
                InitializationDB.Initialize(Context);
            }
            catch (Exception Exception)
            {
                ILogger Logger = ServiceProvider.GetRequiredService<ILogger<Program>>();
                Logger.LogError(Exception, "��������� ������ ��� �������� ���� ������.");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] arguments) => Host.CreateDefaultBuilder(arguments).ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}