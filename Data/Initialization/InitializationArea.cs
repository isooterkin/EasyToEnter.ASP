using Class = EasyToEnter.ASP.Models.Models.AreaModel;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationArea
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    Name = "Дизайн"
                },
                new Class // 2
                {
                    Name = "Искусство и культура"
                },
                new Class // 3
                {
                    Name = "История, археология и документоведение"
                },
                new Class // 4
                {
                    Name = "Качество и управление в технических системах"
                },
                new Class // 5
                {
                    Name = "Логистика"
                },
                new Class // 6
                {
                    Name = "Маркетинг"
                },
                new Class // 7
                {
                    Name = "Математика, информационные науки и технологии"
                },
                new Class // 8
                {
                    Name = "Машиностроение, автоматизация и робототехника"
                },
                new Class // 9
                {
                    Name = "Медицина и здравоохранение"
                },
                new Class // 10
                {
                    Name = "Нанотехнологии и наноматериалы"
                },
                new Class // 11
                {
                    Name = "Науки о земле, геология и геодезия"
                },
                new Class // 12
                {
                    Name = "Образование и педагогика"
                },
                new Class // 13
                {
                    Name = "Оружие и системы вооружения"
                },
                new Class // 14
                {
                    Name = "Политика и международные отношения"
                },
                new Class // 15
                {
                    Name = "Приборостроение, оптика и биотехника"
                },
                new Class // 16
                {
                    Name = "Психология"
                },
                new Class // 17
                {
                    Name = "СМИ, журналистика, реклама и PR"
                },
                new Class // 18
                {
                    Name = "Сельское, лесное и рыбное хозяйство"
                },
                new Class // 19
                {
                    Name = "Сервис, туризм и гостиничное дело"
                },
                new Class // 20
                {
                    Name = "Социология и социальная работа"
                },
                new Class // 21
                {
                    Name = "Строительство, архитектура и недвижимость"
                },
                new Class // 22
                {
                    Name = "Технологии легкой и пищевой промышленности"
                },
                new Class // 23
                {
                    Name = "Технологии материалов и металлургия"
                },
                new Class // 24
                {
                    Name = "Технологические машины, оборудование и спецтранспорт"
                },
                new Class // 25
                {
                    Name = "Торговля и товароведение"
                },
                new Class // 26
                {
                    Name = "Транспорт: наземный, воздушный, водный"
                },
                new Class // 27
                {
                    Name = "Управление и менеджмен"
                },
                new Class // 28
                {
                    Name = "Управление персоналом"
                },
                new Class // 30
                {
                    Name = "Физико-технические науки и технологии"
                },
                new Class // 31
                {
                    Name = "Физическая культура, спорт и фитнес"
                },
                new Class // 32
                {
                    Name = "Филология и лингвистика"
                },
                new Class // 33
                {
                    Name = "Философия и религия"
                },
                new Class // 34
                {
                    Name = "Химико-биологические науки и технологии"
                },
                new Class // 35
                {
                    Name = "Экология, природообустройство и безопасность"
                },
                new Class // 36
                {
                    Name = "Экономика и финансы"
                },
                new Class // 37
                {
                    Name = "Электроника, связь и радиотехника"
                },
                new Class // 38
                {
                    Name = "Энергетика и электротехника"
                },
                new Class // 39
                {
                    Name = "Юриспруденция"
                }
            });

            Context.SaveChanges();
        }
    }
}