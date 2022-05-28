using Class = EasyToEnter.ASP.Models.Models.DisciplineModel;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationDiscipline
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 00
                {
                    Name = ""
                }
            });

            Context.SaveChanges();
        }
    }
}