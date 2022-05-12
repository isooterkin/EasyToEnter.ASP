using Class = EasyToEnter.ASP.Models.Models.SpecializationUniversityModel;

namespace EasyToEnter.ASP.Data.Initialization.Models
{
    public class InitializationSpecializationUniversity
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {

                }
            });

            Context.SaveChanges();
        }
    }
}