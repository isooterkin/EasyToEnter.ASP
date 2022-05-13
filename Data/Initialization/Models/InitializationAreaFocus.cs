using Class = EasyToEnter.ASP.Models.Models.AreaFocusModel;

namespace EasyToEnter.ASP.Data.Initialization.Models
{
    public class InitializationAreaFocus
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