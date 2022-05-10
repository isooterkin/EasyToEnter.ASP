using Class = EasyToEnter.ASP.Models.Models.ScienceModel;

namespace EasyToEnter.ASP.Data.Initialization.Models
{
    public class InitializationScience
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    Name = "Математические и естественные науки"
                },
                new Class // 2
                {
                    Name = "Инженерное дело, технологии и технические науки"
                },
                new Class // 3
                {
                    Name = "Здравоохранение и медицинские науки"
                },
                new Class // 4
                {
                    Name = "Сестринское дело"
                },
                new Class // 5
                {
                    Name = "Сельское хозяйство и сельскохозяйственные"
                },
                new Class // 6
                {
                    Name = "Науки об обществе"
                },
                new Class // 7
                {
                    Name = "Образование и педагогические науки"
                },
                new Class // 8
                {
                    Name = "Гуманитарные науки"
                },
                new Class // 9
                {
                    Name = "Искусство и культура"
                }
            });

            Context.SaveChanges();
        }
    }
}