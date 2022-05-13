using Class = EasyToEnter.ASP.Models.Models.UniversityModel;

namespace EasyToEnter.ASP.Data.Initialization.Models
{
    public class InitializationUniversity
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    Name = "Санкт-Петербургский государственный технологический институт (Технический университет)",
                    Abbreviation = "СПбГТИ(ТУ)",
                    Address = "Россия, Санкт-Петербург, Московский проспект, 24-26/49",
                    EmailAddress = "office@technolog.edu.ru",
                    PhoneNumber = "78127101120",
                    Description = "",
                    Website = "https://technolog.edu.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 78
                }
            });

            Context.SaveChanges();
        }
    }
}