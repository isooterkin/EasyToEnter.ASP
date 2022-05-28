using Class = EasyToEnter.ASP.Models.Models.GroupModel;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationGroup
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    ScienceId = 1,
                    Name = "Математика и механика",
                    Description = "",
                    Code = "01"
                },
                new Class // 2
                {
                    ScienceId = 1,
                    Name = "Компьютерные и информационные науки",
                    Description = "",
                    Code = "02"
                },
                new Class // 3
                {
                    ScienceId = 1,
                    Name = "Физика и астрономия",
                    Description = "",
                    Code = "03"
                },
                new Class // 4
                {
                    ScienceId = 1,
                    Name = "Химия",
                    Description = "",
                    Code = "04"
                },
                new Class // 5
                {
                    ScienceId = 1,
                    Name = "Науки о земле",
                    Description = "",
                    Code = "05"
                },
                new Class // 6
                {
                    ScienceId = 1,
                    Name = "Биологические науки",
                    Description = "",
                    Code = "06"
                },
                new Class // 7
                {
                    ScienceId = 2,
                    Name = "Архитектура",
                    Description = "",
                    Code = "07"
                },
                new Class // 8
                {
                    ScienceId = 2,
                    Name = "Техника и технологии строительства",
                    Description = "",
                    Code = "08"
                },
                new Class // 9
                {
                    ScienceId = 2,
                    Name = "Информатика и вычислительная техника",
                    Description = "",
                    Code = "09"
                },
                new Class // 10
                {
                    ScienceId = 2,
                    Name = "Информационная безопасность",
                    Description = "",
                    Code = "10"
                },
                new Class // 11
                {
                    ScienceId = 2,
                    Name = "Электроника, радиотехника и системы связи",
                    Description = "",
                    Code = "11"
                },
                new Class // 12
                {
                    ScienceId = 2,
                    Name = "Фотоника, приборостроение, оптические и биотехнические системы и технологии",
                    Description = "",
                    Code = "12"
                },
                new Class // 13
                {
                    ScienceId = 2,
                    Name = "Электро- и теплоэнергетика",
                    Description = "",
                    Code = "13"
                },
                new Class // 14
                {
                    ScienceId = 2,
                    Name = "Ядерная энергетика и технологии",
                    Description = "",
                    Code = "14"
                },
                new Class // 15
                {
                    ScienceId = 2,
                    Name = "Машиностроение",
                    Description = "",
                    Code = "15"
                },
                new Class // 16
                {
                    ScienceId = 2,
                    Name = "Физико-технические науки и технологии",
                    Description = "",
                    Code = "16"
                },
                new Class // 17
                {
                    ScienceId = 2,
                    Name = "Оружие и системы вооружения",
                    Description = "",
                    Code = "17"
                },
                new Class // 18
                {
                    ScienceId = 2,
                    Name = "Химические технологии",
                    Description = "",
                    Code = "18"
                },
                new Class // 19
                {
                    ScienceId = 2,
                    Name = "Промышленная экология и биотехнологии",
                    Description = "",
                    Code = "19"
                },
                new Class // 20
                {
                    ScienceId = 2,
                    Name = "Техносферная безопасность и природообустройство",
                    Description = "",
                    Code = "20"
                },
                new Class // 21
                {
                    ScienceId = 2,
                    Name = "Прикладная геология, горное дело, нефтегазовое дело и геодезия",
                    Description = "",
                    Code = "21"
                },
                new Class // 22
                {
                    ScienceId = 2,
                    Name = "Технологии материалов",
                    Description = "",
                    Code = "22"
                },
                new Class // 23
                {
                    ScienceId = 2,
                    Name = "Техника и технологии наземного транспорта",
                    Description = "",
                    Code = "23"
                },
                new Class // 24
                {
                    ScienceId = 2,
                    Name = "Авиационная и ракетно-космическая техника",
                    Description = "",
                    Code = "24"
                },
                new Class // 25
                {
                    ScienceId = 2,
                    Name = "Аэронавигация и эксплуатация авиационной и ракетно-космической техники",
                    Description = "",
                    Code = "25"
                },
                new Class // 26
                {
                    ScienceId = 2,
                    Name = "Техника и технологии кораблестроения и водного транспорта",
                    Description = "",
                    Code = "26"
                },
                new Class // 27
                {
                    ScienceId = 2,
                    Name = "Управление в технических системах",
                    Description = "",
                    Code = "27"
                },
                new Class // 28
                {
                    ScienceId = 2,
                    Name = "Нанотехнологии и материалы",
                    Description = "",
                    Code = "28"
                },
                new Class // 29
                {
                    ScienceId = 2,
                    Name = "Технологии легкой промышленности",
                    Description = "",
                    Code = "29"
                },
                new Class // 30
                {
                    ScienceId = 3,
                    Name = "Фундаментальная медицина",
                    Description = "",
                    Code = "30"
                },
                new Class // 31
                {
                    ScienceId = 3,
                    Name = "Клиническая медицина",
                    Description = "",
                    Code = "31"
                },
                new Class // 32
                {
                    ScienceId = 3,
                    Name = "Науки о здоровье и профилактическая медицина",
                    Description = "",
                    Code = "32"
                },
                new Class // 33
                {
                    ScienceId = 3,
                    Name = "Фармация",
                    Description = "",
                    Code = "33"
                },
                new Class // 34
                {
                    ScienceId = 4,
                    Name = "Сестринское дело",
                    Description = "",
                    Code = "34"
                },
                new Class // 35
                {
                    ScienceId = 5,
                    Name = "Сельское, лесное и рыбное хозяйство",
                    Description = "",
                    Code = "35"
                },
                new Class // 36
                {
                    ScienceId = 5,
                    Name = "Ветеринария и зоотехния",
                    Description = "",
                    Code = "36"
                },
                new Class // 37
                {
                    ScienceId = 6,
                    Name = "Психологические науки",
                    Description = "",
                    Code = "37"
                },
                new Class // 38
                {
                    ScienceId = 6,
                    Name = "Экономика и управление",
                    Description = "",
                    Code = "38"
                },
                new Class // 39
                {
                    ScienceId = 6,
                    Name = "Социология и социальная работа",
                    Description = "",
                    Code = "39"
                },
                new Class // 40
                {
                    ScienceId = 6,
                    Name = "Юриспруденция",
                    Description = "",
                    Code = "40"
                },
                new Class // 41
                {
                    ScienceId = 6,
                    Name = "Политические науки и регионоведение",
                    Description = "",
                    Code = "41"
                },
                new Class // 42
                {
                    ScienceId = 6,
                    Name = "Средства массовой информации и информационно-библиотечное дело",
                    Description = "",
                    Code = "42"
                },
                new Class // 43
                {
                    ScienceId = 6,
                    Name = "Сервис и туризм",
                    Description = "",
                    Code = "43"
                },
                new Class // 44
                {
                    ScienceId = 7,
                    Name = "Образование и педагогические науки",
                    Description = "",
                    Code = "44"
                },
                new Class // 45
                {
                    ScienceId = 8,
                    Name = "Языкознание и литературоведение",
                    Description = "",
                    Code = "45"
                },
                new Class // 46
                {
                    ScienceId = 8,
                    Name = "История и археология",
                    Description = "",
                    Code = "46"
                },
                new Class // 47
                {
                    ScienceId = 8,
                    Name = "Философия, этика и религиоведение",
                    Description = "",
                    Code = "47"
                },
                new Class // 48
                {
                    ScienceId = 8,
                    Name = "Теология",
                    Description = "",
                    Code = "48"
                },
                new Class // 49
                {
                    ScienceId = 8,
                    Name = "Физическая культура и спорт",
                    Description = "",
                    Code = "49"
                },
                new Class // 50
                {
                    ScienceId = 9,
                    Name = "Искусствознание",
                    Description = "",
                    Code = "50"
                },
                new Class // 51
                {
                    ScienceId = 9,
                    Name = "Культуроведение и социокультурные проекты",
                    Description = "",
                    Code = "51"
                },
                new Class // 52
                {
                    ScienceId = 9,
                    Name = "Сценические искусства и литературное творчество",
                    Description = "",
                    Code = "52"
                },
                new Class // 53
                {
                    ScienceId = 9,
                    Name = "Музыкальное искусство",
                    Description = "",
                    Code = "53"
                },
                new Class // 54
                {
                    ScienceId = 9,
                    Name = "Изобразительное и прикладные виды искусств",
                    Description = "",
                    Code = "54"
                },
                new Class // 55
                {
                    ScienceId = 9,
                    Name = "Экранные искусства",
                    Description = "",
                    Code = "55"
                },
                new Class // 56
                {
                    ScienceId = 8,
                    Name = "Востоковедение и африканистика",
                    Description = "",
                    Code = "58"
                }
            });

            Context.SaveChanges();
        }
    }
}