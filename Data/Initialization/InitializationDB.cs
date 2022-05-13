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

            // Добавляем в базу данных "Специализация"
            InitializationSpecialization.Initialize(context);

            // Добавляем в базу данных "Область"
            InitializationArea.Initialize(context);

            // Добавляем в базу данных "Аккредитация"
            InitializationAccreditation.Initialize(context);

            // Добавляем в базу данных "Формат"
            InitializationFormat.Initialize(context);

            // Добавляем в базу данных "Оплата"
            InitializationPayment.Initialize(context);

            // Добавляем в базу данных "Форма"
            InitializationForm.Initialize(context);

            // Добавляем в базу данных "Предмет"
            InitializationSubject.Initialize(context);

            // Добавляем в базу данных "Субъект"
            InitializationRegion.Initialize(context);

            // Добавляем в базу данных "Город"
            InitializationCity.Initialize(context);

            // Добавляем в базу данных "Наука"
            InitializationScience.Initialize(context);

            // Добавляем в базу данных "Уровень"
            InitializationLevel.Initialize(context);

            // Добавляем в базу данных "Группа"
            InitializationGroup.Initialize(context);

            // Добавляем в базу данных "Направление"
            InitializationDirection.Initialize(context);

            // Добавляем в базу данных "Направленность"
            InitializationFocus.Initialize(context);

            // Добавляем в базу данных "Уровень - Направленность"
            InitializationLevelFocus.Initialize(context);

            // Добавляем в базу данных "ВУЗ"
            InitializationUniversity.Initialize(context);

            // Добавляем в базу данных "Общежитие"
            // InitializationDormitory.Initialize(context);

            // Добавляем в базу данных "Область - Направленность"
            // InitializationAreaFocus.Initialize(context);

            // Добавляем в базу данных "Специализация - ВУЗ"
            // InitializationSpecializationUniversity.Initialize(context);

            // Добавляем в базу данных "Направленность ВУЗа"
            // InitializationFocusUniversity.Initialize(context);
        }
    }
}