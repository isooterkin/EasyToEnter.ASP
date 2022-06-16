﻿using Class = EasyToEnter.ASP.Models.Models.FocusUniversityModel;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationFocusUniversity
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    UniversityId = 1,
                    LevelFocusId = 1
                },
                new Class // 2
                {
                    UniversityId = 1,
                    LevelFocusId = 2
                },
                new Class // 3
                {
                    UniversityId = 1,
                    LevelFocusId = 3
                },
                new Class // 4
                {
                    UniversityId = 1,
                    LevelFocusId = 4
                },
                new Class // 5
                {
                    UniversityId = 1,
                    LevelFocusId = 5
                },
                new Class // 6
                {
                    UniversityId = 3,
                    LevelFocusId = 6
                },
                new Class // 7
                {
                    UniversityId = 3,
                    LevelFocusId = 7
                },
                new Class // 8
                {
                    UniversityId = 3,
                    LevelFocusId = 8
                },
                new Class // 9
                {
                    UniversityId = 3,
                    LevelFocusId = 9
                },
                new Class // 10
                {
                    UniversityId = 3,
                    LevelFocusId = 10
                },
                new Class // 11
                {
                    UniversityId = 3,
                    LevelFocusId = 4
                },
                new Class // 12
                {
                    UniversityId = 3,
                    LevelFocusId = 11
                },
                new Class // 13
                {
                    UniversityId = 3,
                    LevelFocusId = 12
                },
                new Class // 14
                {
                    UniversityId = 3,
                    LevelFocusId = 13
                },
                new Class // 15
                {
                    UniversityId = 3,
                    LevelFocusId = 14
                },
                new Class // 16
                {
                    UniversityId = 3,
                    LevelFocusId = 15
                },
                new Class // 17
                {
                    UniversityId = 3,
                    LevelFocusId = 16
                }
            });

            Context.SaveChanges();
        }
    }
}