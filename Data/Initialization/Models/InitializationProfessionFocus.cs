using Class = EasyToEnter.ASP.Models.Models.ProfessionFocusModel;


namespace EasyToEnter.ASP.Data.Initialization.Models
{
    public class InitializationProfessionFocus
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