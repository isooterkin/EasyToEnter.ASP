using Class = EasyToEnter.ASP.Models.Models.ScienceModel;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationScience
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    Name = "Математические и естественные науки",
                    Description = "Описание..."
                },
                new Class // 2
                {
                    Name = "Инженерное дело, технологии и технические науки",
                    Description = "Описание..."
                },
                new Class // 3
                {
                    Name = "Здравоохранение и медицинские науки",
                    Description = "Описание..."
                },
                new Class // 4
                {
                    Name = "Сестринское дело",
                    Description = "Описание..."
                },
                new Class // 5
                {
                    Name = "Сельское хозяйство и сельскохозяйственные",
                    Description = "Описание..."
                },
                new Class // 6
                {
                    Name = "Науки об обществе",
                    Description = "Описание..."
                },
                new Class // 7
                {
                    Name = "Образование и педагогические науки",
                    Description = "Описание..."
                },
                new Class // 8
                {
                    Name = "Гуманитарные науки",
                    Description = "Описание..."
                },
                new Class // 9
                {
                    Name = "Искусство и культура",
                    Description = "Описание..."
                }
            });

            Context.SaveChanges();
        }
    }
}