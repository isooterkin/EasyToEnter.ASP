using Class = EasyToEnter.ASP.Models.Models.LevelFocusModel;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationLevelFocus
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            // ТЕСТОВЫЕ ДАННЫЕ!

            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    FocusId = 1,
                    LevelId = 1
                },
                new Class // 2
                {
                    FocusId = 2,
                    LevelId = 1
                },
                new Class // 3
                {
                    FocusId = 3,
                    LevelId = 1
                },
                new Class // 4
                {
                    FocusId = 4,
                    LevelId = 1
                },
                new Class // 5
                {
                    FocusId = 5,
                    LevelId = 2
                },
                new Class // 6
                {
                    FocusId = 6,
                    LevelId = 1
                },
                new Class // 7
                {
                    FocusId = 7,
                    LevelId = 1
                },
                new Class // 8
                {
                    FocusId = 8,
                    LevelId = 1
                },
                new Class // 9
                {
                    FocusId = 9,
                    LevelId = 1
                },
                new Class // 10
                {
                    FocusId = 10,
                    LevelId = 1
                },
                new Class // 11
                {
                    FocusId = 4,
                    LevelId = 1
                },
                new Class // 12
                {
                    FocusId = 11,
                    LevelId = 1
                },
                new Class // 13
                {
                    FocusId = 12,
                    LevelId = 1
                },
                new Class // 14
                {
                    FocusId = 13,
                    LevelId = 1
                },
                new Class // 15
                {
                    FocusId = 14,
                    LevelId = 1
                },
                new Class // 16
                {
                    FocusId = 15,
                    LevelId = 1
                },
                new Class // 17
                {
                    FocusId = 16,
                    LevelId = 1
                },
                new Class // 18
                {
                    FocusId = 17,
                    LevelId = 1
                }
            });

            Context.SaveChanges();
        }
    }
}