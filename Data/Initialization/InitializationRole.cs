using Class = EasyToEnter.ASP.Models.Models.RoleModel;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationRole
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    Name = "Администратор"
                },
                new Class // 2
                {
                    Name = "Абитуриент"
                },
                new Class // 3
                {
                    Name = "Сотрудник ВУЗа"
                },
                new Class // 4
                {
                    Name = "Работодатель"
                }
            });

            Context.SaveChanges();
        }
    }
}