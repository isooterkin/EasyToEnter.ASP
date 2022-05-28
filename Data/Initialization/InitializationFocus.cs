using Class = EasyToEnter.ASP.Models.Models.FocusModel;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationFocus
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            // ТЕСТОВЫЕ ДАННЫЕ!

            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    Name = "Технологии разработки программного обеспечения",
                    Description = "",
                    DirectionId = 40
                },
                new Class // 2
                {
                    Name = "Разработка программного обеспечения",
                    Description = "",
                    DirectionId = 40
                },
                new Class // 3
                {
                    Name = "Защищенные высокопроизводительные вычислительные системы",
                    Description = "",
                    DirectionId = 40
                },
                new Class // 4
                {
                    Name = "Компьютерные сети и телекоммуникации",
                    Description = "",
                    DirectionId = 40
                },
                new Class // 5
                {
                    Name = "Сетевые информационные технологии",
                    Description = "",
                    DirectionId = 40
                },
                new Class // 6
                {
                    Name = "Программирование и системная интеграция ИТ-решений",
                    Description = "",
                    DirectionId = 40
                },
                new Class // 7
                {
                    Name = "Проектирование информационных систем в экономике",
                    Description = "",
                    DirectionId = 40
                },
                new Class // 8
                {
                    Name = "Компьютерные системы и технологии",
                    Description = "",
                    DirectionId = 40
                },
                new Class // 9
                {
                    Name = "Интеллектуальные системы управления и обработки информации",
                    Description = "",
                    DirectionId = 40
                },
                new Class // 10
                {
                    Name = "Программная инженерия и компьютерные науки",
                    Description = "",
                    DirectionId = 40
                },
                new Class // 11
                {
                    Name = "Цифровая педагогика",
                    Description = "",
                    DirectionId = 40
                },
                new Class // 12
                {
                    Name = "Инфраструктура информационных технологий",
                    Description = "",
                    DirectionId = 40
                },
                new Class // 13
                {
                    Name = "Автоматизированные системы обработки информации и управления",
                    Description = "",
                    DirectionId = 40
                },
                new Class // 14
                {
                    Name = "Интеграция и программирование САПР",
                    Description = "",
                    DirectionId = 40
                },
                new Class // 15
                {
                    Name = "Информационные системы",
                    Description = "",
                    DirectionId = 40
                },
                new Class // 16
                {
                    Name = "Проектирование и эксплуатация IT-инфраструктуры",
                    Description = "",
                    DirectionId = 40
                },
                new Class // 17
                {
                    Name = "Биология",
                    Description = "",
                    DirectionId = 28
                },
                new Class // 18
                {
                    Name = "Почвоведение",
                    Description = "",
                    DirectionId = 28
                },
                new Class // 19
                {
                    Name = "Физика, мелиорация и эрозия почв",
                    Description = "",
                    DirectionId = 29
                },
                new Class // 20
                {
                    Name = "Земельные ресурсы и функционирование почв",
                    Description = "",
                    DirectionId = 29
                },
                new Class // 21
                {
                    Name = "Химия почв",
                    Description = "",
                    DirectionId = 29
                },
                new Class // 22
                {
                    Name = "Агроинформатика и цифровые агротехнологии",
                    Description = "",
                    DirectionId = 29
                },
                new Class // 23
                {
                    Name = "Информационные системы и технологии",
                    Description = "",
                    DirectionId = 41
                },
                new Class // 24
                {
                    Name = "Информационные системы и технологии в геодезии и картографии",
                    Description = "",
                    DirectionId = 41
                },
                new Class // 25
                {
                    Name = "Информационные системы в нефтегазовой отрасли",
                    Description = "",
                    DirectionId = 41
                },
                new Class // 26
                {
                    Name = "Безопасность компьютерных систем",
                    Description = "",
                    DirectionId = 44
                },
                new Class // 27
                {
                    Name = "Организация и технология защиты информации (на транспорте)",
                    Description = "",
                    DirectionId = 44
                },
                new Class // 28
                {
                    Name = "Техническая защита информации",
                    Description = "",
                    DirectionId = 44
                }
            });

            Context.SaveChanges();
        }
    }
}