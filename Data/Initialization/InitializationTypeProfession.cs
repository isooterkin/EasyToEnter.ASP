using Class = EasyToEnter.ASP.Models.Models.TypeProfessionModel;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationTypeProfession
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
				{
                    Name = "Строительство и жилищно-коммунальное хозяйство",
                    Description = null
                },
                new Class // 2
				{
                    Name = "Сквозные виды профессиональной деятельности",
                    Description = null
                },
                new Class // 3
				{
                    Name = "Административно-управленческая и офисная деятельность",
                    Description = null
                },
                new Class // 4
				{
                    Name = "Судостроение",
                    Description = null
                },
                new Class // 5
				{
                    Name = "Авиастроение",
                    Description = null
                },
                new Class // 6
				{
                    Name = "Автомобилестроение",
                    Description = null
                },
                new Class // 7
				{
                    Name = "Архитектура, проектирование, геодезия, топография и дизайн",
                    Description = null
                },
                new Class // 8
				{
                    Name = "Атомная промышленность",
                    Description = null
                },
                new Class // 9
				{
                    Name = "Деревообрабатывающая и целлюлозно-бумажная промышленность, мебельное производство",
                    Description = null
                },
                new Class // 10
				{
                    Name = "Добыча, переработка, транспортировка нефти и газа",
                    Description = null
                },
                new Class // 11
				{
                    Name = "Здравоохранение",
                    Description = null
                },
                new Class // 12
				{
                    Name = "Культура, искусство",
                    Description = null
                },
                new Class // 13
				{
                    Name = "Лесное хозяйство, охота",
                    Description = null
                },
                new Class // 14
				{
                    Name = "Металлургическое производство",
                    Description = null
                },
                new Class // 15
				{
                    Name = "Обеспечение безопасности",
                    Description = null
                },
                new Class // 16
				{
                    Name = "Образование и наука",
                    Description = null
                },
                new Class // 17
				{
                    Name = "Пищевая промышленность, включая производство напитков и табака",
                    Description = null
                },
                new Class // 18
				{
                    Name = "Производство машин и оборудования",
                    Description = null
                },
                new Class // 19
				{
                    Name = "Производство электрооборудования, электронного и оптического оборудования",
                    Description = null
                },
                new Class // 20
				{
                    Name = "Ракетно-космическая промышленность",
                    Description = null
                },
                new Class // 21
				{
                    Name = "Рыбоводство и рыболовство",
                    Description = null
                },
                new Class // 22
				{
                    Name = "Связь, информационные и коммуникационные технологии",
                    Description = null
                },
                new Class // 23
				{
                    Name = "Сельское хозяйство",
                    Description = null
                },
                new Class // 24
				{
                    Name = "Сервис, оказание услуг населению (торговля, техническое обслуживание, ремонт, предоставление персональных услуг, услуги гостеприимства, общественное питание и пр.)",
                    Description = null
                },
                new Class // 25
				{
                    Name = "Социальное обслуживание",
                    Description = null
                },
                new Class // 26
				{
                    Name = "Финансы и экономика",
                    Description = null
                },
                new Class // 27
				{
                    Name = "Средства массовой информации, издательство и полиграфия",
                    Description = null
                },
                new Class // 28
				{
                    Name = "Транспорт",
                    Description = null
                },
                new Class // 29
				{
                    Name = "Физическая культура и спорт",
                    Description = null
                },
                new Class // 30
				{
                    Name = "Химическое, химико-технологическое производство",
                    Description = null
                },
                new Class // 31
				{
                    Name = "Электроэнергетика",
                    Description = null
                },
                new Class // 32
				{
                    Name = "Легкая и текстильная промышленность",
                    Description = null
                },
                new Class // 33
				{
                    Name = "Добыча, переработка угля, руд и других полезных ископаемых",
                    Description = null
                },
                new Class // 34
				{
                    Name = "Юриспруденция",
                    Description = null
                },
            });

            Context.SaveChanges();
        }
    }
}