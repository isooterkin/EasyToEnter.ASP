using Class = EasyToEnter.ASP.Models.Models.SubjectModel;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationSubject
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    Name = "Биология"
                },
                new Class // 2
                {
                    Name = "География"
                },
                new Class // 3
                {
                    Name = "Иностранный язык"
                },
                new Class // 4
                {
                    Name = "Информатика и ИКТ"
                },
                new Class // 5
                {
                    Name = "История"
                },
                new Class // 6
                {
                    Name = "Литература"
                },
                new Class // 7
                {
                    Name = "Математика"
                },
                new Class // 8
                {
                    Name = "Обществознание"
                },
                new Class // 9
                {
                    Name = "Русский язык"
                },
                new Class // 10
                {
                    Name = "Физика"
                },
                new Class // 11
                {
                    Name = "Химия"
                }
            });

            Context.SaveChanges();
        }
    }
}