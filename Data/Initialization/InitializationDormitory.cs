using Class = EasyToEnter.ASP.Models.Models.DormitoryModel;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationDormitory
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                // Санкт-Петербургский государственный технологический институт (Технический университет)
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
                },
                // Санкт-Петербургский политехнический университет Петра Великого
                new Class // 7
                {
                    Name = "Политех общежитие 1",
                    UniversityId = 3,
                    AddressId = 71,
                    Amount = 955,
                    PhoneNumber = null,
                },
                new Class // 8
                {
                    Name = "Общежитие 3 СПбГПУ",
                    UniversityId = 3,
                    AddressId = 72,
                    Amount = 955,
                    PhoneNumber = "78122954160",
                },
                new Class // 9
                {
                    Name = "Политех общежитие 4",
                    UniversityId = 3,
                    AddressId = 73,
                    Amount = 955,
                    PhoneNumber = "78122954555",
                },
                new Class // 10
                {
                    Name = "Общежитие 4а СПбГПУ",
                    UniversityId = 3,
                    AddressId = 74,
                    Amount = 955,
                    PhoneNumber = "78122950006",
                },
                new Class // 11
                {
                    Name = "Общежитие 5, 5б СПбГПУ",
                    UniversityId = 3,
                    AddressId = 75,
                    Amount = 955,
                    PhoneNumber = "78122954725",
                },
                new Class // 12
                {
                    Name = "Общежитие 6 Политехнического университета",
                    UniversityId = 3,
                    AddressId = 76,
                    Amount = 955,
                    PhoneNumber = "78122952750",
                },
                new Class // 13
                {
                    Name = "№7",
                    UniversityId = 3,
                    AddressId = 77,
                    Amount = 955,
                    PhoneNumber = "79215611329",
                },
                new Class // 14
                {
                    Name = "№11",
                    UniversityId = 3,
                    AddressId = 78,
                    Amount = 955,
                    PhoneNumber = "78122950028",
                },
                new Class // 15
                {
                    Name = "№8",
                    UniversityId = 3,
                    AddressId = 79,
                    Amount = 955,
                    PhoneNumber = "78122974350",
                },
                new Class // 16
                {
                    Name = "Общежитие 10 Политех",
                    UniversityId = 3,
                    AddressId = 80,
                    Amount = 955,
                    PhoneNumber = "78122971678",
                },
                new Class // 17
                {
                    Name = "№12",
                    UniversityId = 3,
                    AddressId = 81,
                    Amount = 955,
                    PhoneNumber = "78125344786",
                },
                new Class // 18
                {
                    Name = "№14а",
                    UniversityId = 3,
                    AddressId = 82,
                    Amount = 955,
                    PhoneNumber = "78125962667",
                },
                new Class // 19
                {
                    Name = "№14б",
                    UniversityId = 3,
                    AddressId = 83,
                    Amount = 955,
                    PhoneNumber = "78125962932",
                },
                new Class // 20
                {
                    Name = "Общежитие 14 ц Политех",
                    UniversityId = 3,
                    AddressId = 84,
                    Amount = 955,
                    PhoneNumber = "78125344893",
                },
                new Class // 21
                {
                    Name = "Общежитие 17 Политех",
                    UniversityId = 3,
                    AddressId = 85,
                    Amount = 955,
                    PhoneNumber = "78125552332",
                },
                new Class // 22
                {
                    Name = "СПбГПУ общежитие 18",
                    UniversityId = 3,
                    AddressId = 86,
                    Amount = 955,
                    PhoneNumber = "78125557697",
                },
                new Class // 23
                {
                    Name = "№13",
                    UniversityId = 3,
                    AddressId = 87,
                    Amount = 955,
                    PhoneNumber = "78125344665",
                },
                new Class // 24
                {
                    Name = "№15",
                    UniversityId = 3,
                    AddressId = 88,
                    Amount = 955,
                    PhoneNumber = "78125340358",
                },
                new Class // 25
                {
                    Name = "№16",
                    UniversityId = 3,
                    AddressId = 89,
                    Amount = 955,
                    PhoneNumber = "78125178766",
                },
                new Class // 26
                {
                    Name = "Политех общежитие 19",
                    UniversityId = 3,
                    AddressId = 90,
                    Amount = 955,
                    PhoneNumber = "78123736796",
                },
                new Class // 27
                {
                    Name = "№ 20",
                    UniversityId = 3,
                    AddressId = 91,
                    Amount = 955,
                    PhoneNumber = "78123165508",
                }
            });

            Context.SaveChanges();
        }
    }
}