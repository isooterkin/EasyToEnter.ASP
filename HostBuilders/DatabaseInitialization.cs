using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Data.Initialization;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.HostBuilders
{
    public static class DatabaseInitialization
    {
        public static IHost AddDatabaseInitialization(this IHost host)
        {
            using IServiceScope ServiceScope = host.Services.CreateScope();
            EasyToEnterDbContextFactory contextFactory = ServiceScope.ServiceProvider.GetRequiredService<EasyToEnterDbContextFactory>();
            using EasyToEnterDbContext context = contextFactory.CreateDbContext();

            try
            {
                // Миграция
                context.Database.Migrate();

                // Была ли ранее создана БД
                if (context.Science.Any()) return host;

                // Добавляем в базу данных "Специализация" +++
                InitializationSpecialization.Initialize(context);

                // Добавляем в базу данных "Область" +++
                InitializationArea.Initialize(context);

                // Добавляем в базу данных "Аккредитация" +++
                InitializationAccreditation.Initialize(context);

                // Добавляем в базу данных "Формат" +++
                InitializationFormat.Initialize(context);

                // Добавляем в базу данных "Оплата" +++
                InitializationPayment.Initialize(context);

                // Добавляем в базу данных "Форма" +++
                InitializationForm.Initialize(context);

                // Добавляем в базу данных "Предмет" +++
                InitializationSubject.Initialize(context);

                // Добавляем в базу данных "Субъект" +++ (можно дополнить)
                InitializationRegion.Initialize(context);

                // Добавляем в базу данных "Город" +++ (можно дополнить)
                InitializationCity.Initialize(context);

                // Добавляем в базу данных "Наука" +++
                InitializationScience.Initialize(context);

                // Добавляем в базу данных "Уровень" +++
                InitializationLevel.Initialize(context);

                // Добавляем в базу данных "Группа" +++
                InitializationGroup.Initialize(context);

                // Добавляем в базу данных "Направление"
                InitializationDirection.Initialize(context);

                // Добавляем в базу данных "Направленность"
                InitializationFocus.Initialize(context);

                // Добавляем в базу данных "Тип профессии" +++ (можно дополнить, но незнаю чем)
                InitializationTypeProfession.Initialize(context);

                // Добавляем в базу данных "Профессия" +++ (можно дополнить, но незнаю чем)
                InitializationProfession.Initialize(context);

                // Добавляем в базу данных "Профессия - Направленность"
                // InitializationProfessionFocus.Initialize(context);

                // Добавляем в базу данных "Уровень - Направленность"
                InitializationLevelFocus.Initialize(context);

                // Добавляем в базу данных "Адрес"
                InitializationAddress.Initialize(context);

                // Добавляем в базу данных "ВУЗ" +++ (можно дополнить)
                InitializationUniversity.Initialize(context);

                // Добавляем в базу данных "Контактный телефон"
                InitializationPhoneNumberUniversity.Initialize(context);

                // Добавляем в базу данных "Общежитие" +++ (можно дополнить)
                InitializationDormitory.Initialize(context);

                // Добавляем в базу данных "Область - Направленность"
                // InitializationAreaFocus.Initialize(context);

                // Добавляем в базу данных "Специализация - ВУЗ"
                // InitializationSpecializationUniversity.Initialize(context);

                // Добавляем в базу данных "Направленность ВУЗа"
                InitializationFocusUniversity.Initialize(context);

                // Добавляем в базу данных "Предмет направленности ВУЗа"
                // InitializationSubjectFocusUniversity.Initialize(context);

                // Добавляем в базу данных "Предмет на замену"
                // InitializationSubjectReplacement.Initialize(context);

                // Добавляем в базу данных "Дисциплина"
                // InitializationDiscipline.Initialize(context);

                // Добавляем в базу данных "Дисциплина направленности ВУЗа"
                // InitializationDisciplineFocusUniversity.Initialize(context);

                // Добавляем в базу данных "Вариативность"
                InitializationVariability.Initialize(context);

                // Добавляем в базу данных "История вариативности"
                // InitializationHistoryVariability.Initialize(context);

                // Добавляем в базу данных "Роль"
                InitializationRole.Initialize(context);

                // Добавляем в базу данных "Пользователей"
                InitializationPerson.Initialize(context);
            }
            catch (Exception Exception)
            {
                ILogger Logger = ServiceScope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                Logger.LogError(Exception, "Произошла ошибка при заполнении базы данных.");
            }

            return host;
        }
    }
}