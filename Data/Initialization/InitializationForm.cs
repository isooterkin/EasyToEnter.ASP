using Class = EasyToEnter.ASP.Models.Models.FormModel;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationForm
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    Name = "Выходного дня",
                    Description = "Обучение в группах «выходного дня» организовано один или два раза в неделю в выходные дни"
                },
                new Class // 2
                {
                    Name = "Дистанционно",
                    Description = "Образовательный процесс с применением технологий, обеспечивающих связь обучающихся и преподавателей на расстоянии"
                },
                new Class // 3
                {
                    Name = "Заочно",
                    Description = "Форма учёбы, которая сочетает в себе черты самообучения и очной учёбы"
                },
                new Class // 4
                {
                    Name = "Очно",
                    Description = "Учащийся осваивает программу непосредственно в стенах учебного заведения,в таком же формате, как в школе"
                },
                new Class // 5
                {
                    Name = "Очно-заочно",
                    Description = "Способ получения образовательного материала посредством посещения занятий в выходные дни или в будни, в вечернее время"
                }
            });

            Context.SaveChanges();
        }
    }
}