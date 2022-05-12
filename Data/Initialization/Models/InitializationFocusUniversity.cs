using Class = EasyToEnter.ASP.Models.Models.FocusUniversityModel;

namespace EasyToEnter.ASP.Data.Initialization.Models
{
    public class InitializationFocusUniversity
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