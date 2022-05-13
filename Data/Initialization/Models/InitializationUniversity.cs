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
                    Address = "Россия, г. Санкт-Петербург, Московский проспект, 24-26/49",
                    EmailAddress = "office@technolog.edu.ru",
                    PhoneNumber = "78127101120",
                    Description = "",
                    Website = "https://technolog.edu.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 2
                {
                    Name = "Санкт-Петербургский филиал Национального исследовательского университета «Высшая школа экономики»",
                    Abbreviation = "НИУ ВШЭ",
                    Address = "Россия, г. Санкт-Петербург, ул. Кантемировская, д. 3, к.1, лит. А",
                    EmailAddress = "abitur-spb@hse.ru",
                    PhoneNumber = "78126446212",
                    Description = "",
                    Website = "https://spb.hse.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 3
                {
                    Name = "Санкт-Петербургский политехнический университет Петра Великого",
                    Abbreviation = "СПбПУ",
                    Address = "Россия, г. Санкт-Петербург, ул. Политехническая, д. 29",
                    EmailAddress = "abitur@spbstu.ru",
                    PhoneNumber = "78127750530",
                    Description = "",
                    Website = "http://www.spbstu.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 4
                {
                    Name = "Университет «Реавиз» в Санкт-Петербурге",
                    Abbreviation = "Реавиз в СПб",
                    Address = "Россия, г. Санкт-Петербург, ул. Калинина, д. 8, к. 2, лит. А",
                    EmailAddress = "spb@reaviz.ru",
                    PhoneNumber = "78126129950",
                    Description = "",
                    Website = "https://spbreaviz.ru",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                    CityId = 79
                },
                new Class // 5
                {
                    Name = "Санкт-Петербургский Гуманитарный университет профсоюзов",
                    Abbreviation = "СПбГУП",
                    Address = "Россия, г. Санкт-Петербург, ул. Фучика, д. 15",
                    EmailAddress = "pricom@gup.ru",
                    PhoneNumber = "88003335202",
                    Description = "",
                    Website = "http://www.gup.ru",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                    CityId = 79
                },
                new Class // 6
                {
                    Name = "Санкт-Петербургский государственный университет промышленных технологий и дизайна",
                    Abbreviation = "СПбГУПТД",
                    Address = "Россия, г. Санкт-Петербург, ул. Большая Морская, д. 18",
                    EmailAddress = "priemcom@sutd.ru",
                    PhoneNumber = "78123150747",
                    Description = "",
                    Website = "http://www.sutd.ru",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 7
                {
                    Name = "Художественно-технический институт",
                    Abbreviation = "ВХУТЕИН",
                    Address = "Россия, г. Санкт-Петербург, ул. Моховая, д. 40",
                    EmailAddress = "abiturient@vhutein.ru",
                    PhoneNumber = "78129208843",
                    Description = "",
                    Website = "https://vhutein.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                    CityId = 79
                },
                new Class // 8
                {
                    Name = "Санкт-Петербургский реставрационно-строительный институт",
                    Abbreviation = "СПбРСИ",
                    Address = "Россия, г. Санкт-Петербург, ул. Лифляндская, д. 2-4, лит. Ц",
                    EmailAddress = "priem@spbiir.ru",
                    PhoneNumber = "78125005172",
                    Description = "",
                    Website = "https://spbrsi.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                    CityId = 79
                },
                new Class // 9
                {
                    Name = "Университет при Межпарламентской Ассамблее ЕврАзЭС",
                    Abbreviation = "Университете при МПА ЕврАзЭС",
                    Address = "Россия, г. Санкт-Петербург, ул. Смолячкова, д. 16, лит. С",
                    EmailAddress = "miep.priem@mail.ru",
                    PhoneNumber = "78126408000",
                    Description = "",
                    Website = "https://www.miep.edu.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                    CityId = 79
                },
                new Class // 10
                {
                    Name = "Санкт-Петербургский государственный университет телекоммуникаций им. проф. М.А. Бонч-Бруевича",
                    Abbreviation = "СПбГУТ",
                    Address = "Россия, г. Санкт-Петербург, пр. Большевиков, д. 22, к. 1",
                    EmailAddress = "pk@sut.ru",
                    PhoneNumber = "78123051218",
                    Description = "",
                    Website = "http://priem.sut.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 11
                {
                    Name = "Балтийский государственный технический университет «ВОЕНМЕХ» им. Д.Ф. Устинова",
                    Abbreviation = "БГТУ ВОЕНМЕХ им. Д.Ф.",
                    Address = "Россия, г. Санкт-Петербург, ул. 1-я Красноармейская, д. 1",
                    EmailAddress = "admission@voenmeh.ru",
                    PhoneNumber = "78124957620",
                    Description = "",
                    Website = "www.voenmeh.ru",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 12
                {
                    Name = "Северо-Западный институт управления - филиал Российской академии народного хозяйства и государственной службы при Президенте Российской Федерации",
                    Abbreviation = "Северо-Западном институте управления РАНХиГС",
                    Address = "Россия, г. Санкт-Петербург, Средний пр. В. О., д. 57/43",
                    EmailAddress = "priem-sziu@ranepa.ru",
                    PhoneNumber = "78123233311",
                    Description = "",
                    Website = "https://priem.spb.ranepa.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 13
                {
                    Name = "Санкт-Петербургский государственный экономический университет",
                    Abbreviation = "СПбГЭУ",
                    Address = "Россия, г. Санкт-Петербург, ул. Садовая, д. 21",
                    EmailAddress = "abitura@unecon.ru",
                    PhoneNumber = "78124589758",
                    Description = "",
                    Website = "https://unecon.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 14
                {
                    Name = "СПБГУ - Санкт-Петербургский государственный университет",
                    Abbreviation = "СПбГУ",
                    Address = "Россия, г. Санкт-Петербург, Университетская наб., д. 7-9",
                    EmailAddress = "abiturient@spbu.ru",
                    PhoneNumber = "78123636636",
                    Description = "",
                    Website = "http://abiturient.spbu.ru",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 15
                {
                    Name = "Санкт-Петербургский государственный университет аэрокосмического приборостроения",
                    Abbreviation = "ГУАП",
                    Address = "Россия, г. Санкт-Петербург, ул. Якубовича, д. 26",
                    EmailAddress = "priem@guap.ru",
                    PhoneNumber = "78123122107",
                    Description = "",
                    Website = "http://guap.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 16
                {
                    Name = "Санкт-Петербургский государственный электротехнический университет «ЛЭТИ» им. В.И. Ульянова (Ленина)",
                    Abbreviation = "СПбГЭТУ «ЛЭТИ»",
                    Address = "Россия, г. Санкт-Петербург, ул. Профессора Попова, д. 5, к. 5",
                    EmailAddress = "prcom@etu.ru",
                    PhoneNumber = "78123258705",
                    Description = "",
                    Website = "https://etu.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 17
                {
                    Name = "Российский государственный педагогический университет им. А.И. Герцена",
                    Abbreviation = "РГПУ им. А.И. Герцена",
                    Address = "Россия, г. Санкт-Петербург, наб. р. Мойки, д. 48, к. 6",
                    EmailAddress = "pk@herzen.spb.ru",
                    PhoneNumber = "78126437766",
                    Description = "",
                    Website = "http://www.herzen.spb.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 18
                {
                    Name = "Петербургский государственный университет путей сообщения Императора Александра I",
                    Abbreviation = "ПГУПС",
                    Address = "Россия, г. Санкт-Петербург, Московский пр., д. 9",
                    EmailAddress = "primkom@pgups.ru",
                    PhoneNumber = "78124578242",
                    Description = "",
                    Website = "https://priem.pgups.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 19
                {
                    Name = "Российский государственный институт сценических искусств",
                    Abbreviation = "РГИСИ",
                    Address = "Россия, г. Санкт-Петербург, ул. Моховая, д. 33",
                    EmailAddress = "pk@rgisi.ru",
                    PhoneNumber = "78122731072",
                    Description = "",
                    Website = "http://www.rgisi.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 20
                {
                    Name = "Санкт-Петербургский университет технологий управления и экономики",
                    Abbreviation = "СПбУТУиЭ",
                    Address = "Россия, г. Санкт-Петербург, Лермонтовский пр-т, д. 44, лит. А",
                    EmailAddress = "rector@spbume.ru",
                    PhoneNumber = "78006008676",
                    Description = "",
                    Website = "www.spbume.ru",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                    CityId = 79
                },
                new Class // 21
                {
                    Name = "Северо-Западный филиал Российского государственного университета правосудия",
                    Abbreviation = "СЗФ РГУП",
                    Address = "Россия, г. Санкт-Петербург, Александровский парк, д. 5",
                    EmailAddress = "priem@szfrgup.ru",
                    PhoneNumber = "78126556455",
                    Description = "",
                    Website = "http://nwb.rgup.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 22
                {
                    Name = "Санкт-Петербургский имени В.Б. Бобкова филиал Российской таможенной академии",
                    Abbreviation = "XXX",
                    Address = "Россия, г. Санкт-Петербург, ул. Софийская, д. 52, лит. А",
                    EmailAddress = "odo@spbrta.ru",
                    PhoneNumber = "78127061219",
                    Description = "",
                    Website = "https://spbrta.customs.gov.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 23
                {
                    Name = "Балтийская академия туризма и предпринимательства",
                    Abbreviation = "БАТиП",
                    Address = "Россия, г. Санкт-Петербург, ул. Петрозаводская, д.13, лит. А",
                    EmailAddress = "priem@batp.ru",
                    PhoneNumber = "78122354109",
                    Description = "",
                    Website = "http://batp.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                    CityId = 79
                },
                new Class // 24
                {
                    Name = "Санкт-Петербургский горный университет",
                    Abbreviation = "Горный университет",
                    Address = "Россия, г. Санкт-Петербург, наб. Лейтенанта Шмидта, д. 49",
                    EmailAddress = "abitur@spmi.ru",
                    PhoneNumber = "78005501434",
                    Description = "",
                    Website = "https://priem.spmi.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 25
                {
                    Name = "Российский государственный гидрометеорологический университет",
                    Abbreviation = "РГГМУ",
                    Address = "Россия, г. Санкт-Петербург, Малоохтинский пр., д. 98",
                    EmailAddress = "dovus@rshu.ru",
                    PhoneNumber = "78123725091",
                    Description = "",
                    Website = "http://www.rshu.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 26
                {
                    Name = "Санкт-Петербургский государственный аграрный университет",
                    Abbreviation = "СПбГАУ",
                    Address = "Россия, г. Пушкин, Петербургское ш., д. 2",
                    EmailAddress = "pk_spbgau@mail.ru",
                    PhoneNumber = "78124519080",
                    Description = "",
                    Website = "http://spbgau.ru",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 27
                {
                    Name = "Высшая школа менеджмента СПбГУ",
                    Abbreviation = "ВШМ СПбГУ",
                    Address = "Россия, г. Санкт-Петербург, Волховский пер., д. 3",
                    EmailAddress = "abitur@gsom.spbu.ru",
                    PhoneNumber = "78123238462",
                    Description = "",
                    Website = "http://gsom.spbu.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 28
                {
                    Name = "Санкт-Петербургский государственный морской технический университет",
                    Abbreviation = "СПбГМТУ",
                    Address = "Россия, г. Санкт-Петербург, Ленинский пр., д. 101",
                    EmailAddress = "priem@smtu.ru",
                    PhoneNumber = "78127571677",
                    Description = "",
                    Website = "https://www.smtu.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 29
                {
                    Name = "Международный банковский институт имени Анатолия Собчака",
                    Abbreviation = "МБИ им. А. Собчака",
                    Address = "Россия, г. Санкт-Петербург, ул. Малая Садовая, д. 6",
                    EmailAddress = "ibispb@ibispb.ru",
                    PhoneNumber = "78125705576",
                    Description = "",
                    Website = "https://www.ibispb.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                    CityId = 79
                },
                new Class // 30
                {
                    Name = "Академия Русского балета имени А.Я. Вагановой",
                    Abbreviation = "XXX",
                    Address = "Россия, г. Санкт-Петербург, ул. Зодчего Росси, д. 2",
                    EmailAddress = "info@vaganovaacademy.ru",
                    PhoneNumber = "78124560765",
                    Description = "",
                    Website = "http://www.vaganovaacademy.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 31
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 32
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 33
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 34
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 35
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 36
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 37
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 38
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 39
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 40
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 41
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 42
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 43
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 44
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 45
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 46
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 47
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 48
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 49
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 50
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 51
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 52
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 53
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 54
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 55
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 56
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 57
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 58
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 59
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 60
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 61
                {
                    Name = "",
                    Abbreviation = "",
                    Address = "Россия, ",
                    EmailAddress = "",
                    PhoneNumber = "",
                    Description = "",
                    Website = "",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                }
            });

            Context.SaveChanges();
        }
    }
}