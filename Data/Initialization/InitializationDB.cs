using EasyToEnter.ASP.Data.Initialization.Models;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationDB
    {
        public static void Initialize(EasyToEnterDbContext context)
        {
            // Удаляем БД если она существует
            // Context.Database.EnsureDeleted();

            // Создаем БД если она не существует
            context.Database.EnsureCreated();

            // Была ли ранее создана БД
            if (context.Science.Any()) return;

            // Добавляем в базу данных "Наука"
            InitializationScience.Initialize(context);

            // Добавляем в базу данных "Уровень"
            InitializationLevel.Initialize(context);

            // Добавляем в базу данных "Группа"
            InitializationGroup.Initialize(context);

            // Добавляем в базу данных "Направление"
            InitializationDirection.Initialize(context);

            // Добавляем в базу данных "Направленность"
            // InitializationFocus.Initialize(context);

            // Добавляем в базу данных "Уровень - Направленность"
            // InitializationLevelGroup.Initialize(context);
        }
    }
}