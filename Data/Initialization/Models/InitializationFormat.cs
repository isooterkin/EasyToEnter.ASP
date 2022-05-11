using Class = EasyToEnter.ASP.Models.Models.FormatModel;

namespace EasyToEnter.ASP.Data.Initialization.Models
{
    public class InitializationFormat
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    Name = "Второе высшее"
                },
                new Class // 2
                {
                    Name = "Полный курс"
                },
                new Class // 3
                {
                    Name = "Ускоренно (после СПО)"
                }
            });

            Context.SaveChanges();
        }
    }
}