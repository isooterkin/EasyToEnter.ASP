using Class = EasyToEnter.ASP.Models.Models.AccreditationModel;

namespace EasyToEnter.ASP.Data.Initialization.Models
{
    public class InitializationAccreditation
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    Name = "Государственные вузы"
                },
                new Class // 2
                {
                    Name = "Негосударственные вузы"
                }
            });

            Context.SaveChanges();
        }
    }
}