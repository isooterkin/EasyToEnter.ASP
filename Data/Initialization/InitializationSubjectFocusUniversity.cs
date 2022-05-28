using Class = EasyToEnter.ASP.Models.Models.SubjectFocusUniversityModel;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationSubjectFocusUniversity
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 00
                {

                }
            });

            Context.SaveChanges();
        }
    }
}