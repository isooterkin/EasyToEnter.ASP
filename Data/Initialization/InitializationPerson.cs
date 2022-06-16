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
                    Login = "administrator",
                    PasswordHash = "$2a$11$5/kzRaV.CL45VhQw8kGOpunl1x2UR/odjA8dB2AAAHrQ3gxAJYTaa",
                    FirstName = null,
                    MiddleName = null,
                    LastName = null,
                    PhoneNumber = null,
                    EmailAddress = null,
                    DateOfBirth = null
                },
                new Class // 2
                {
                    RoleId = 2, // Абитуриент
                    Login = "applicant1",
                    PasswordHash = "$2a$11$5/kzRaV.CL45VhQw8kGOpunl1x2UR/odjA8dB2AAAHrQ3gxAJYTaa",
                    FirstName = "Виктория",
                    MiddleName = null,
                    LastName = null,
                    PhoneNumber = null,
                    EmailAddress = null,
                    DateOfBirth = null
                },
                new Class // 3
                {
                    RoleId = 2, // Абитуриент
                    Login = "applicant2",
                    PasswordHash = "$2a$11$5/kzRaV.CL45VhQw8kGOpunl1x2UR/odjA8dB2AAAHrQ3gxAJYTaa",
                    FirstName = "Мария",
                    MiddleName = null,
                    LastName = null,
                    PhoneNumber = null,
                    EmailAddress = null,
                    DateOfBirth = null
                },
                new Class // 4
                {
                    RoleId = 3, // Сотрудник ВУЗа
                    Login = "university1",
                    PasswordHash = "$2a$11$5/kzRaV.CL45VhQw8kGOpunl1x2UR/odjA8dB2AAAHrQ3gxAJYTaa",
                    FirstName = "Костя",
                    MiddleName = null,
                    LastName = null,
                    PhoneNumber = null,
                    EmailAddress = null,
                    DateOfBirth = null
                },
                new Class // 5
                {
                    RoleId = 3, // Сотрудник ВУЗа
                    Login = "university2",
                    PasswordHash = "$2a$11$5/kzRaV.CL45VhQw8kGOpunl1x2UR/odjA8dB2AAAHrQ3gxAJYTaa",
                    FirstName = "Никита",
                    MiddleName = null,
                    LastName = null,
                    PhoneNumber = null,
                    EmailAddress = null,
                    DateOfBirth = null
                },
                new Class // 6
                {
                    RoleId = 4, // Работодатель
                    Login = "organization1",
                    PasswordHash = "$2a$11$5/kzRaV.CL45VhQw8kGOpunl1x2UR/odjA8dB2AAAHrQ3gxAJYTaa",
                    FirstName = "Влад",
                    MiddleName = null,
                    LastName = null,
                    PhoneNumber = null,
                    EmailAddress = null,
                    DateOfBirth = null
                },
                new Class // 7
                {
                    RoleId = 4, // Работодатель
                    Login = "organization2",
                    PasswordHash = "$2a$11$5/kzRaV.CL45VhQw8kGOpunl1x2UR/odjA8dB2AAAHrQ3gxAJYTaa",
                    FirstName = "Артем",
                    MiddleName = null,
                    LastName = null,
                    PhoneNumber = null,
                    EmailAddress = null,
                    DateOfBirth = null
                }
            });

            Context.SaveChanges();
        }
    }
}