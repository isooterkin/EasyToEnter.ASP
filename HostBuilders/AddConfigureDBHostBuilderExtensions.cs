using EasyToEnter.ASP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using EasyToEnter.ASP.Services.Discipline;
using System.Net.Http.Headers;

namespace EasyToEnter.ASP.HostBuilders
{
    public static class AddConfigureDBHostBuilderExtensions
    {
        private static readonly string DBName = "PGSQL"; // MYSQL MSSQL PGSQL

        public static IHostBuilder AddConfigureDB(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                // Конфигурация БД
                string connectionString = context.Configuration.GetConnectionString(DBName);

                void configureDbContext(DbContextOptionsBuilder o)
                {
                    // Строка подключения к БД
                    switch (DBName)
                    {
                        case "MYSQL":
                            o.UseSqlServer(connectionString);
                            break;
                        case "MSSQL":
                            o.UseMySQL(connectionString);
                            break;
                        case "PGSQL":
                            o.UseNpgsql(connectionString);
                            break;
                        default:
                            o.UseNpgsql(connectionString);
                            break;
                    }

                    // Убрать предупреждение о большом количестве Include
                    o.ConfigureWarnings(x => x.Ignore(RelationalEventId.MultipleCollectionIncludeWarning));
                }

                // Регистрация контекста БД
                services.AddDbContextPool<EasyToEnterDbContext>(configureDbContext);

                // Регистрация завода контекста БД
                services.AddSingleton(new EasyToEnterDbContextFactory(configureDbContext));
            });

            return host;
        }
    }
}