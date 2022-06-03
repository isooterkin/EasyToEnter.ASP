using Class = EasyToEnter.ASP.Models.Models.PersonModel;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationPerson
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    RoleId = 1, // Администратор
                    Login = "isooterkin",
                    PasswordHash = "$2a$11$4OjopWvrfAhOlskDSuwNKexbTrkcFbZfabelkGBjoAfDyTBcP9SFu",
                    FirstName = "Кирилл",
                    MiddleName = "Александрович",
                    LastName = "Пархом",
                    PhoneNumber = "89121858950",
                    EmailAddress = "isooterkin@gmail.com",
                    DateOfBirth = new DateOnly(1998, 12, 21)
                }
            });

            Context.SaveChanges();
        }
    }
}