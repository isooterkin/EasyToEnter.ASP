using Class = EasyToEnter.ASP.Models.Models.VariabilityModel;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationVariability
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