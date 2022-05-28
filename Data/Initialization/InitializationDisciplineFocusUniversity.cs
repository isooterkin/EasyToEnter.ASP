using Class = EasyToEnter.ASP.Models.Models.DisciplineFocusUniversityModel;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationDisciplineFocusUniversity
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 00
                {
                    DisciplineCredit = 0,
                    FocusUniversityId = 0,
                    DisciplineId = 0
                }
            });

            Context.SaveChanges();
        }
    }
}