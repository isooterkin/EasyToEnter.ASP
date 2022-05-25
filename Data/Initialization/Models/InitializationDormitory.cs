using Class = EasyToEnter.ASP.Models.Models.DormitoryModel;

namespace EasyToEnter.ASP.Data.Initialization.Models
{
    public class InitializationDormitory
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    Name = "Общежитие №1",
                    UniversityId = 1,
                    AddressId = 65,
                    Amount = 965,
                    PhoneNumber = "730-69-48",
                },
                new Class // 2
                {
                    Name = "Общежитие №2",
                    UniversityId = 1,
                    AddressId = 66,
                    Amount = 945,
                    PhoneNumber = "744-17-67",
                },
                new Class // 3
                {
                    Name = "Общежитие №3",
                    UniversityId = 1,
                    AddressId = 67,
                    Amount = 965,
                    PhoneNumber = "736-54-94",
                },
                new Class // 4
                {
                    Name = "Общежитие №4",
                    UniversityId = 1,
                    AddressId = 68,
                    Amount = 820,
                    PhoneNumber = "387-63-37",
                },
                new Class // 5
                {
                    Name = "Общежитие №5",
                    UniversityId = 1,
                    AddressId = 69,
                    Amount = 780,
                    PhoneNumber = "252-69-63",
                },
                new Class // 6
                {
                    Name = "Общежитие №6",
                    UniversityId = 1,
                    AddressId = 70,
                    Amount = 780,
                    PhoneNumber = "755-19-01",
                }
            });

            Context.SaveChanges();
        }
    }
}