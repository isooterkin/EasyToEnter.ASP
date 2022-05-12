using Class = EasyToEnter.ASP.Models.Models.SpecializationModel;

namespace EasyToEnter.ASP.Data.Initialization.Models
{
    public class InitializationSpecialization
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    Name = "Авиационные"
                },
                new Class // 2
                {
                    Name = "Банковские"
                },
                new Class // 3
                {
                    Name = "Военные"
                },
                new Class // 4
                {
                    Name = "Гуманитарные"
                },
                new Class // 5
                {
                    Name = "Дизайнерские"
                },
                new Class // 6
                {
                    Name = "Дистанционные"
                },
                new Class // 7
                {
                    Name = "Естественно-научные"
                },
                new Class // 8
                {
                    Name = "Железнодорожные"
                },
                new Class // 9
                {
                    Name = "Информационные"
                },
                new Class // 10
                {
                    Name = "Лингвистические"
                },
                new Class // 11
                {
                    Name = "Медицинские"
                },
                new Class // 12
                {
                    Name = "Музыкальные"
                },
                new Class // 13
                {
                    Name = "Педагогические"
                },
                new Class // 14
                {
                    Name = "Психологические"
                },
                new Class // 15
                {
                    Name = "Связи"
                },
                new Class // 16
                {
                    Name = "Сельскохозяйственные"
                },
                new Class // 17
                {
                    Name = "Спортивные"
                },
                new Class // 18
                {
                    Name = "Строительные"
                },
                new Class // 19
                {
                    Name = "Таможенные"
                },
                new Class // 20
                {
                    Name = "Творческие, культуры"
                },
                new Class // 21
                {
                    Name = "Театральные"
                },
                new Class // 22
                {
                    Name = "Технические"
                },
                new Class // 23
                {
                    Name = "Технологические"
                },
                new Class // 24
                {
                    Name = "Транспортные"
                },
                new Class // 25
                {
                    Name = "Фармацевтические"
                },
                new Class // 26
                {
                    Name = "Физические"
                },
                new Class // 27
                {
                    Name = "Художественные"
                },
                new Class // 28
                {
                    Name = "Экономические"
                },
                new Class // 29
                {
                    Name = "Юридические"
                }
            });

            Context.SaveChanges();
        }
    }
}