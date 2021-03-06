using EasyToEnter.ASP.Data.Initialization.Models;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationDB
    {
        public static void Initialize(EasyToEnterDbContext context)
        {
            // Удаляем БД если она существует
            // context.Database.EnsureDeleted();

            // Создаем БД если она не существует
            context.Database.EnsureCreated();

            // Была ли ранее создана БД
            if (context.Science.Any()) return;

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
            // InitializationFocusUniversity.Initialize(context);

            // Добавляем в базу данных "Предмет направленности ВУЗа"
            // InitializationSubjectFocusUniversity.Initialize(context);

            // Добавляем в базу данных "Предмет на замену"
            // InitializationSubjectReplacement.Initialize(context);

            // Добавляем в базу данных "Дисциплина"
            // InitializationDiscipline.Initialize(context);

            // Добавляем в базу данных "Дисциплина направленности ВУЗа"
            // InitializationDisciplineFocusUniversity.Initialize(context);

            // Добавляем в базу данных "Вариативность"
            // InitializationVariability.Initialize(context);

            // Добавляем в базу данных "История вариативности"
            // InitializationHistoryVariability.Initialize(context);
        }
    }
}