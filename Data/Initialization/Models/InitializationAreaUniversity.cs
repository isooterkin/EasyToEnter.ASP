using Class = EasyToEnter.ASP.Models.Models.AreaUniversityModel;

namespace EasyToEnter.ASP.Data.Initialization.Models
{
    public class InitializationAreaUniversity
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