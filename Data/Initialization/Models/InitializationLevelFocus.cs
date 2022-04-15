using Class = EasyToEnter.ASP.Models.Models.LevelFocusModel;

namespace EasyToEnter.ASP.Data.Initialization.Models
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
                    LevelId = 1
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
                    FocusId = 11,
                    LevelId = 1
                },
                new Class // 12
                {
                    FocusId = 12,
                    LevelId = 1
                },
                new Class // 13
                {
                    FocusId = 13,
                    LevelId = 1
                },
                new Class // 14
                {
                    FocusId = 16,
                    LevelId = 2
                },
                new Class // 15
                {
                    FocusId = 15,
                    LevelId = 2
                },
                new Class // 16
                {
                    FocusId = 14,
                    LevelId = 2
                },
                new Class // 17
                {
                    FocusId = 13,
                    LevelId = 2
                },
                new Class // 18
                {
                    FocusId = 5,
                    LevelId = 2
                },
                new Class // 19
                {
                    FocusId = 6,
                    LevelId = 2
                },
                new Class // 20
                {
                    FocusId = 9,
                    LevelId = 3
                },
                new Class // 21
                {
                    FocusId = 11,
                    LevelId = 3
                },
                new Class // 22
                {
                    FocusId = 15,
                    LevelId = 4
                },
                new Class // 23
                {
                    FocusId = 2,
                    LevelId = 4
                },
                new Class // 24
                {
                    FocusId = 4,
                    LevelId = 4
                },
                new Class // 25
                {
                    FocusId = 17,
                    LevelId = 1
                },
                new Class // 26
                {
                    FocusId = 18,
                    LevelId = 1
                },
                new Class // 27
                {
                    FocusId = 19,
                    LevelId = 1
                },
                new Class // 28
                {
                    FocusId = 20,
                    LevelId = 2
                },
                new Class // 29
                {
                    FocusId = 21,
                    LevelId = 2
                },
                new Class // 30
                {
                    FocusId = 22,
                    LevelId = 2
                },
                new Class // 31
                {
                    FocusId = 20,
                    LevelId = 3
                },
                new Class // 32
                {
                    FocusId = 21,
                    LevelId = 4
                },
                new Class // 33
                {
                    FocusId = 23,
                    LevelId = 1
                },
                new Class // 34
                {
                    FocusId = 24,
                    LevelId = 1
                },
                new Class // 35
                {
                    FocusId = 25,
                    LevelId = 2
                },
                new Class // 36
                {
                    FocusId = 26,
                    LevelId = 2
                },
                new Class // 37
                {
                    FocusId = 26,
                    LevelId = 4
                },
                new Class // 38
                {
                    FocusId = 23,
                    LevelId = 3
                },
                new Class // 39
                {
                    FocusId = 27,
                    LevelId = 1
                },
                new Class // 40
                {
                    FocusId = 28,
                    LevelId = 2
                },
                new Class // 41
                {
                    FocusId = 29,
                    LevelId = 3
                },
                new Class // 42
                {
                    FocusId = 27,
                    LevelId = 4
                },
            });

            Context.SaveChanges();
        }
    }
}