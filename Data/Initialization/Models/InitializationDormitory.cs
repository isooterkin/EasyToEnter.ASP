using Class = EasyToEnter.ASP.Models.Models.DormitoryModel;

namespace EasyToEnter.ASP.Data.Initialization.Models
{
    public class InitializationDormitory
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