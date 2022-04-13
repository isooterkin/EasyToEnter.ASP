namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationDB
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            // Удаляем БД если она существует
            // Context.Database.EnsureDeleted();

            // Создаем БД если она не существует
            Context.Database.EnsureCreated();

            // Была ли ранее создана БД
            //if (Context.Science.Any()) return;

            // Добавляем в базу данных "Наука"
            //InitializationScience.Initialize(Context);

            // Добавляем в базу данных "Уровень"
            //InitializationLevel.Initialize(Context);

            // Добавляем в базу данных "Группа"
            //InitializationGroup.Initialize(Context);

            // Добавляем в базу данных "Уровень - Группа"
            //InitializationLevelGroup.Initialize(Context);

            // Добавляем в базу данных "Направление"
            //InitializationDirection.Initialize(Context);
        }
    }
}