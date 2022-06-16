using Class = EasyToEnter.ASP.Models.Models.OrganizationModel;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationOrganization
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    Name = "Бизнес Технологии",
                    EmailAddress = "global.system@sipnet.ru",
                    Description = "Бизнес Технологии - ведущий разработчик ИТ-решений и поставщик услуг в области цифровой трансформации бизнеса. Компания разрабатывает российскую ERP-систему Global, бизнес-приложения и платформу Global-FrameWork для цифровизации процессов управления производством, ремонтами, складами, финансами, торговли, персоналом, документооборотом. Программные продукты, создаваемые компанией включены в реестр российского программного обеспечения и соответствуют требованиям импортозамещения.",
                    PhoneNumber = "78126330733"
                },
                new Class // 2
                {
                    Name = "Внедренцы и Программисты",
                    EmailAddress = "job@vprogers.ru",
                    Description = "Мы — не просто ещё один официальный партнер 1С. У нас многолетний опыт работы в реальном секторе. Работали как наемными сотрудниками крупных компаний, так и сами на себя. Знаем бизнес изнутри и давно изучили все лазейки и подводные камни при внедрении новых решений.",
                    PhoneNumber = "78123098839"
                }
            });

            Context.SaveChanges();
        }
    }
}