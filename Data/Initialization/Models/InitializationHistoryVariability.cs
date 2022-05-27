using Class = EasyToEnter.ASP.Models.Models.HistoryVariabilityModel;

namespace EasyToEnter.ASP.Data.Initialization.Models
{
    public class InitializationHistoryVariability
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