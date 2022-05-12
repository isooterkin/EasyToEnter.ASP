using Class = EasyToEnter.ASP.Models.Models.UniversityModel;

namespace EasyToEnter.ASP.Data.Initialization.Models
{
    public class InitializationUniversity
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    Name = ""
                }
            });

            Context.SaveChanges();
        }
    }
}