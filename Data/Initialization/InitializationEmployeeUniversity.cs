using Class = EasyToEnter.ASP.Models.Models.EmployeeUniversityModel;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationEmployeeUniversity
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    UniversityId = 1,
                    PersonId = 4,
                },
                new Class // 2
                {
                    UniversityId = 3,
                    PersonId = 5,
                }
            });

            Context.SaveChanges();
        }
    }
}