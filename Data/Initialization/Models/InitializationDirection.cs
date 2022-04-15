using Class = EasyToEnter.ASP.Models.Models.DirectionModel;

namespace EasyToEnter.ASP.Data.Initialization.Models
{
    public class InitializationDirection
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    GroupId = 1,
                    Name = "Математика",
                    Description = "",
                    Code = "01"
                },
                new Class // 2
                {
                    GroupId = 1,
                    Name = "Прикладная математика и информатика",
                    Description = "",
                    Code = "02"
                },
                new Class // 3
                {
                    GroupId = 1,
                    Name = "Механика и математическое моделирование",
                    Description = "",
                    Code = "03"
                },
                new Class // 4
                {
                    GroupId = 1,
                    Name = "Прикладная математика",
                    Description = "",
                    Code = "04"
                },
                new Class // 5
                {
                    GroupId = 1,
                    Name = "Статистика",
                    Description = "",
                    Code = "05"
                },
                new Class // 6
                {
                    GroupId = 1,
                    Name = "Фундаментальные математика и механика",
                    Description = "",
                    Code = "01"
                },
                new Class // 7
                {
                    GroupId = 1,
                    Name = "Математика и механика",
                    Description = "",
                    Code = "01"
                },
                new Class // 8
                {
                    GroupId = 2,
                    Name = "Математика и компьютерные науки",
                    Description = "",
                    Code = "01"
                },
                new Class // 9
                {
                    GroupId = 2,
                    Name = "Фундаментальная информатика и информационные технологии",
                    Description = "",
                    Code = "02"
                },
                new Class // 10
                {
                    GroupId = 2,
                    Name = "Математическое обеспечение и администрирование информационных систем",
                    Description = "",
                    Code = "03"
                },
                new Class // 11
                {
                    GroupId = 2,
                    Name = "Компьютерные и информационные технологии",
                    Description = "",
                    Code = "01"
                },
                new Class // 12
                {
                    GroupId = 3,
                    Name = "Прикладные математика и физика",
                    Description = "",
                    Code = "01"
                },
                new Class // 13
                {
                    GroupId = 3,
                    Name = "Физика",
                    Description = "",
                    Code = "02"
                },
                new Class // 14
                {
                    GroupId = 3,
                    Name = "Радиофизика",
                    Description = "",
                    Code = "03"
                },
                new Class // 15
                {
                    GroupId = 3,
                    Name = "Астрономия",
                    Description = "",
                    Code = "01"
                },
                new Class // 16
                {
                    GroupId = 3,
                    Name = "Физика и астрономия",
                    Description = "",
                    Code = "01"
                },
                new Class // 17
                {
                    GroupId = 4,
                    Name = "Химия",
                    Description = "",
                    Code = "01"
                },
                new Class // 18
                {
                    GroupId = 4,
                    Name = "Химия, физика и механика материалов",
                    Description = "",
                    Code = "02"
                },
                new Class // 19
                {
                    GroupId = 4,
                    Name = "Фундаментальная и прикладная химия",
                    Description = "",
                    Code = "01"
                },
                new Class // 20
                {
                    GroupId = 4,
                    Name = "Химические науки",
                    Description = "",
                    Code = "01"
                },
                new Class // 21
                {
                    GroupId = 5,
                    Name = "Геология",
                    Description = "",
                    Code = "01"
                },
                new Class // 22
                {
                    GroupId = 5,
                    Name = "География",
                    Description = "",
                    Code = "02"
                },
                new Class // 23
                {
                    GroupId = 5,
                    Name = "Картография и геоинформатика",
                    Description = "",
                    Code = "03"
                },
                new Class // 24
                {
                    GroupId = 5,
                    Name = "Гидрометеорология",
                    Description = "",
                    Code = "04"
                },
                new Class // 25
                {
                    GroupId = 5,
                    Name = "Прикладная гидрометеорология",
                    Description = "",
                    Code = "05"
                },
                new Class // 26
                {
                    GroupId = 5,
                    Name = "Экология и природопользование",
                    Description = "",
                    Code = "06"
                },
                new Class // 27
                {
                    GroupId = 5,
                    Name = "Науки о земле",
                    Description = "",
                    Code = "01"
                },
                new Class // 28
                {
                    GroupId = 6,
                    Name = "Биология",
                    Description = "",
                    Code = "01"
                },
                new Class // 29
                {
                    GroupId = 6,
                    Name = "Почвоведение",
                    Description = "",
                    Code = "02"
                },
                new Class // 30
                {
                    GroupId = 6,
                    Name = "Биоинженерия и биоинформатика",
                    Description = "",
                    Code = "01"
                },
                new Class // 31
                {
                    GroupId = 6,
                    Name = "Биологические науки",
                    Description = "",
                    Code = "01"
                },
                new Class // 32
                {
                    GroupId = 7,
                    Name = "Архитектура",
                    Description = "",
                    Code = "01"
                },
                new Class // 33
                {
                    GroupId = 7,
                    Name = "Реконструкция и реставрация архитектурного наследия",
                    Description = "",
                    Code = "02"
                },
                new Class // 34
                {
                    GroupId = 7,
                    Name = "Дизайн архитектурной среды",
                    Description = "",
                    Code = "03"
                },
                new Class // 35
                {
                    GroupId = 7,
                    Name = "Градостроительство",
                    Description = "",
                    Code = "04"
                },
                new Class // 36
                {
                    GroupId = 8,
                    Name = "Строительство",
                    Description = "",
                    Code = "01"
                },
                new Class // 37
                {
                    GroupId = 8,
                    Name = "Строительство уникальных зданий и сооружений",
                    Description = "",
                    Code = "01"
                },
                new Class // 38
                {
                    GroupId = 8,
                    Name = "Строительство, эксплуатация, восстановление и техническое прикрытие автомобильных дорог, мостов и тоннелей",
                    Description = "",
                    Code = "02"
                },
                new Class // 39
                {
                    GroupId = 8,
                    Name = "Техника и технологии строительства",
                    Description = "",
                    Code = "01"
                },
                new Class // 40
                {
                    GroupId = 9,
                    Name = "Информатика и вычислительная техника",
                    Description = "",
                    Code = "01"
                },
                new Class // 41
                {
                    GroupId = 9,
                    Name = "Информационные системы и технологии",
                    Description = "",
                    Code = "02"
                },
                new Class // 42
                {
                    GroupId = 9,
                    Name = "Прикладная информатика",
                    Description = "",
                    Code = "03"
                },
                new Class // 43
                {
                    GroupId = 9,
                    Name = "Программная инженерия",
                    Description = "",
                    Code = "04"
                },
                new Class // 44
                {
                    GroupId = 10,
                    Name = "Информационная безопасность",
                    Description = "",
                    Code = "01"
                },
                new Class // 45
                {
                    GroupId = 10,
                    Name = "Компьютерная безопасность",
                    Description = "",
                    Code = "01"
                },
                new Class // 46
                {
                    GroupId = 10,
                    Name = "Информационная безопасность телекоммуникационных систем",
                    Description = "",
                    Code = "02"
                },
                new Class // 47
                {
                    GroupId = 10,
                    Name = "Информационная безопасность автоматизированных систем",
                    Description = "",
                    Code = "03"
                },
                new Class // 48
                {
                    GroupId = 10,
                    Name = "Информационно-аналитические системы безопасности",
                    Description = "",
                    Code = "04"
                },
                new Class // 49
                {
                    GroupId = 10,
                    Name = "Безопасность информационных технологий в правоохранительной сфере",
                    Description = "",
                    Code = "05"
                },
                new Class // 50
                {
                    GroupId = 11,
                    Name = "Радиотехника",
                    Description = "",
                    Code = "01"
                },
                new Class // 51
                {
                    GroupId = 11,
                    Name = "Инфокоммуникационные технологии и системы связи",
                    Description = "",
                    Code = "02"
                },
                new Class // 52
                {
                    GroupId = 11,
                    Name = "Конструирование и технология электронных средств",
                    Description = "",
                    Code = "03"
                },
                new Class // 53
                {
                    GroupId = 11,
                    Name = "Электроника и наноэлектроника",
                    Description = "",
                    Code = "04"
                },
                new Class // 54
                {
                    GroupId = 11,
                    Name = "Радиоэлектронные системы и комплексы",
                    Description = "",
                    Code = "01"
                },
                new Class // 55
                {
                    GroupId = 11,
                    Name = "Специальные радиотехнические системы",
                    Description = "",
                    Code = "02"
                },
                new Class // 56
                {
                    GroupId = 11,
                    Name = "Электроника, радиотехника и системы связи",
                    Description = "",
                    Code = "01"
                }
            });

            Context.SaveChanges();
        }
    }
}