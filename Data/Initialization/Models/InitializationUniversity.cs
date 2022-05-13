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
                    Abbreviation = "Университет при МПА ЕврАзЭС",
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
                    Abbreviation = "Северо-Западный институт управления РАНХиГС",
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
                    Abbreviation = "Санкт-Петербургский филиал РТА им. В.Б. Бобкова",
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
                    Abbreviation = "АРБ им. А.Я.Вагановой",
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
                    Name = "Санкт-Петербургский институт (филиал) Всероссийского государственного университета юстиции (РПА Минюста России)",
                    Abbreviation = "Санкт-Петербургский институте (филиал) ВГУЮ (РПА Минюста России)",
                    Address = "Россия, г. Санкт-Петербург, Васильевский остров, 10-я линия, д. 19, литер А",
                    EmailAddress = "pk@szfrpa.ru",
                    PhoneNumber = "78123284521",
                    Description = "",
                    Website = "https://spb.rpa-mu.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 32
                {
                    Name = "Национальный открытый институт г. Санкт-Петербург",
                    Abbreviation = "НОИ СПб",
                    Address = "Россия, г. Санкт-Петербург, ул. Сестрорецкая, д. 6",
                    EmailAddress = "info@noironline.ru",
                    PhoneNumber = "78124306040",
                    Description = "",
                    Website = "https://noironline.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                    CityId = 79
                },
                new Class // 33
                {
                    Name = "Санкт-Петербургский государственный химико-фармацевтический университет",
                    Abbreviation = "СПХФУ",
                    Address = "Россия, г. Санкт-Петербург, ул. Профессора Попова, д. 14 ",
                    EmailAddress = "info@pharminnotech.com",
                    PhoneNumber = "78124993920",
                    Description = "",
                    Website = "http://spcpu.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 34
                {
                    Name = "Государственный университет морского и речного флота имени адмирала С.О. Макарова",
                    Abbreviation = "ГУМРФ им. адм. С.О. Макарова",
                    Address = "Россия, г. Санкт-Петербург, ул. Двинская, д. 5/7",
                    EmailAddress = "otd_o@gumrf.ru",
                    PhoneNumber = "78127489712",
                    Description = "",
                    Website = "www.gumrf.ru",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 35
                {
                    Name = "Санкт-Петербургский государственный лесотехнический университет имени С.М. Кирова",
                    Abbreviation = "СПбГЛТУ им. С.М. Кирова",
                    Address = "Россия, г. Санкт-Петербург, Институтский пер., д. 5",
                    EmailAddress = "pricomlt@mail.ru",
                    PhoneNumber = "78126709297",
                    Description = "",
                    Website = "https://spbftu.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 36
                {
                    Name = "Санкт-Петербургский государственный академический институт живописи, скульптуры и архитектуры имени И.Е. Репина при Российской академии художеств",
                    Abbreviation = "Институт имени И.Е. Репина",
                    Address = "Россия, г. Санкт-Петербург, Университетская наб., д. 17",
                    EmailAddress = "repinpriem@gmail.com",
                    PhoneNumber = "78123236189",
                    Description = "",
                    Website = "http://www.artsacademy.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 37
                {
                    Name = "Санкт-Петербургская государственная консерватория им. Н.А. Римского-Корсакова",
                    Abbreviation = "СПбГК им. Н.А. Римского-Корсакова",
                    Address = "Россия, г. Санкт-Петербург, Театральная пл., д. 3",
                    EmailAddress = "rectorat@conservatory.ru",
                    PhoneNumber = "78125717567",
                    Description = "",
                    Website = "http://www.conservatory.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 38
                {
                    Name = "Санкт-Петербургский национальный исследовательский Академический университет имени Ж.И. Алфёрова Российской академии наук (Алферовский университет)",
                    Abbreviation = "СПбАУ РАН им. Ж.И. Алфёрова",
                    Address = "Россия, г. Санкт-Петербург, ул. Хлопина, д. 8, корп. 3, лит. А",
                    EmailAddress = "admission@spbau.ru",
                    PhoneNumber = "78124486980",
                    Description = "",
                    Website = "http://spbau.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 39
                {
                    Name = "Русская христианская гуманитарная академия",
                    Abbreviation = "РХГА",
                    Address = "Россия, г. Санкт-Петербург, наб. р. Фонтанки, д. 15, лит. А",
                    EmailAddress = "abiturient@rhga.ru",
                    PhoneNumber = "78123341441",
                    Description = "",
                    Website = "https://rhga.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                    CityId = 79
                },
                new Class // 40
                {
                    Name = "Северо-Западный государственный медицинский университет имени И.И. Мечникова",
                    Abbreviation = "СЗГМУ им. И.И. Мечникова",
                    Address = "Россия, г. Санкт-Петербург, Пискаревский пр., д. 47",
                    EmailAddress = "rectorat@szgmu.ru",
                    PhoneNumber = "78123035053",
                    Description = "",
                    Website = "http://szgmu.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 41
                {
                    Name = "Санкт-Петербургский государственный институт психологии и социальной работы",
                    Abbreviation = "СПбГИПСР",
                    Address = "Россия, г. Санкт-Петербург, 12-я линия В. О., д. 13, лит. А",
                    EmailAddress = "priem@gipsr.ru",
                    PhoneNumber = "78123230770",
                    Description = "",
                    Website = "http://www.psysocwork.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 42
                {
                    Name = "Санкт-Петербургский университет Государственной противопожарной службы Министерства Российской Федерации по делам гражданской обороны, чрезвычайным ситуациям и ликвидации последствий стихийных бедствий",
                    Abbreviation = "Санкт-Петербургский университет ГПС МЧС России",
                    Address = "Россия, г. Санкт-Петербург, Московский пр-т, д. 149",
                    EmailAddress = "baranov.n@igps.ru",
                    PhoneNumber = "78123695518",
                    Description = "",
                    Website = "http://www.igps.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 43
                {
                    Name = "Санкт-Петербургский институт экономики и управления",
                    Abbreviation = "СПбИЭУ",
                    Address = "Россия, г. Санкт-Петербург, Крапивный пер., д. 5",
                    EmailAddress = "spbiem@yandex.ru",
                    PhoneNumber = "78123099906",
                    Description = "",
                    Website = "https://www.spbiem.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                    CityId = 79
                },
                new Class // 44
                {
                    Name = "Санкт-Петербургский университет Федеральной службы исполнения наказаний",
                    Abbreviation = "Университет ФСИН России",
                    Address = "Россия, г. Санкт-Петербург, г. Пушкин, ул. Сапёрная, д. 34",
                    EmailAddress = "spbu@fsin.gov.ru",
                    PhoneNumber = "78124165611",
                    Description = "",
                    Website = "https://spbu.fsin.gov.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 45
                {
                    Name = "Первый Санкт-Петербургский государственный медицинский университет имени академика И.П. Павлова",
                    Abbreviation = "ПСПбГМУ им. И.П. Павлова",
                    Address = "Россия, г. Санкт-Петербург, ул. Льва Толстого, д. 6-8",
                    EmailAddress = "priemkom@spb-gmu.ru",
                    PhoneNumber = "78123387112",
                    Description = "",
                    Website = "http://www.1spbgmu.ru/ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 46
                {
                    Name = "Ленинградский государственный университет имени А.С. Пушкина",
                    Abbreviation = "ЛГУ им. А.С. Пушкина",
                    Address = "Россия, г. Санкт-Петербург, г. Пушкин, Петербургское ш., д. 10",
                    EmailAddress = "pushkin@lengu.ru",
                    PhoneNumber = "78124656699",
                    Description = "",
                    Website = "http://lengu.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 47
                {
                    Name = "Санкт-Петербургский государственный университет гражданской авиации",
                    Abbreviation = "СПбГУ ГА",
                    Address = "Россия, г. Санкт-Петербург, ул. Пилотов, д. 38",
                    EmailAddress = "info@spbguga.ru",
                    PhoneNumber = "78127041557",
                    Description = "",
                    Website = "http://www.spbguga.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 48
                {
                    Name = "Национальный государственный университет физической культуры, спорта и здоровья имени П.Ф. Лесгафта",
                    Abbreviation = "НГУ им. П.Ф. Лесгафта",
                    Address = "Россия, г. Санкт-Петербург, ул. Декабристов, д. 35",
                    EmailAddress = "abiturientlesgaft@lesgaft.spb.ru",
                    PhoneNumber = "78127140674",
                    Description = "",
                    Website = "http://lesgaft.spb.ru",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 49
                {
                    Name = "Санкт-Петербургский государственный институт культуры",
                    Abbreviation = "СПбГИК",
                    Address = "Россия, г. Санкт-Петербург, Дворцовая наб., д. 2",
                    EmailAddress = "pk@spbgik.ru",
                    PhoneNumber = "78123189710",
                    Description = "",
                    Website = "http://www.spbgik.ru",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 50
                {
                    Name = "Высшая школа народных искусств (академия)",
                    Abbreviation = "ВШНИ",
                    Address = "Россия, г. Санкт-Петербург, наб. канала Грибоедова, д. 2, лит. А",
                    EmailAddress = "vshni@mail.ru",
                    PhoneNumber = "78127104821",
                    Description = "",
                    Website = "http://www.vshni.ru",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 51
                {
                    Name = "Санкт-Петербургская государственная художественно-промышленная академия имени А.Л. Штиглица",
                    Abbreviation = "СПГХПА им. А.Л. Штиглица",
                    Address = "Россия, г. Санкт-Петербург, Соляной переулок, д.13",
                    EmailAddress = "assistant@ghpa.ru",
                    PhoneNumber = "78122733804",
                    Description = "",
                    Website = "http://www.ghpa.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 52
                {
                    Name = "Санкт-Петербургский филиал Финансового университета при Правительстве Российской Федерации",
                    Abbreviation = "Санкт-Петербургский филиал Финуниверситета​",
                    Address = "Россия, г. Санкт-Петербург, ул. Съезжинская, д. 15-17",
                    EmailAddress = "spb_mail@fa.ru",
                    PhoneNumber = "7 8122324971",
                    Description = "",
                    Website = "http://www.fa.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 53
                {
                    Name = "Институт медицинского образования Национального медицинского исследовательского центра имени В. А. Алмазова",
                    Abbreviation = "Институт медицинского образования НМИЦ им. В. А. Алмазова",
                    Address = "Россия, г. Санкт-Петербург, ул. Аккуратова, д. 11А",
                    EmailAddress = "pk@almazovcentre.ru",
                    PhoneNumber = "78126704483",
                    Description = "",
                    Website = "http://education.almazovcentre.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 54
                {
                    Name = "Санкт-Петербургский медико-социальный институт",
                    Abbreviation = "СПбМСИ",
                    Address = "Россия, г. Санкт-Петербург, Кондратьевский пр., д. 72, лит. А",
                    EmailAddress = "abiturient@medinstitut.org",
                    PhoneNumber = "78129742324",
                    Description = "",
                    Website = "https://medinstitut.org/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                    CityId = 79
                },
                new Class // 55
                {
                    Name = "Европейский университет в Санкт-Петербурге",
                    Abbreviation = "ЕУСПб",
                    Address = "Россия, г. Санкт-Петербург, Гагаринская ул., д. 6/1, лит. А",
                    EmailAddress = "admissions@eu.spb.ru",
                    PhoneNumber = "78123867646",
                    Description = "",
                    Website = "https://eusp.org/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                    CityId = 79
                },
                new Class // 56
                {
                    Name = "Санкт-Петербургский государственный педиатрический медицинский университет",
                    Abbreviation = "СПбГПМУ",
                    Address = "Россия, г. Санкт-Петербург, ул. Литовская, д. 2",
                    EmailAddress = "gpmu_priem@mail.ru",
                    PhoneNumber = "78124165444",
                    Description = "",
                    Website = "http://gpmu.org/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 57
                {
                    Name = "Национальный исследовательский университет ИТМО",
                    Abbreviation = "Университет ИТМО",
                    Address = "Россия, г. Санкт-Петербург, Кронверкский пр., д. 49",
                    EmailAddress = "abit@itmo.ru",
                    PhoneNumber = "78124571858",
                    Description = "",
                    Website = "http://www.ifmo.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 58
                {
                    Name = "Санкт-Петербургский государственный архитектурно-строительный университет",
                    Abbreviation = "СПбГАСУ",
                    Address = "Россия, г. Санкт-Петербург, ул. 2-я Красноармейская, д. 4",
                    EmailAddress = "prc@spbgasu.ru",
                    PhoneNumber = "78123161123",
                    Description = "",
                    Website = "http://www.spbgasu.ru",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 59
                {
                    Name = "Санкт-Петербургский государственный университет ветеринарной медицины",
                    Abbreviation = "СПбГУВМ",
                    Address = "Россия, г. Санкт-Петербург, ул. Черниговская, д. 5",
                    EmailAddress = "spbgavm-priem@mail.ru",
                    PhoneNumber = "78123875144",
                    Description = "",
                    Website = "https://www.spbgavm.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 60
                {
                    Name = "Санкт-Петербургский государственный институт кино и телевидения",
                    Abbreviation = "СПбГИКиТ",
                    Address = "Россия, г. Санкт-Петербург, ул. Правды, д. 13",
                    EmailAddress = "priem@gukit.ru",
                    PhoneNumber = "78123157483",
                    Description = "",
                    Website = "http://www.gukit.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 61
                {
                    Name = "Северо-Западный открытый технический университет",
                    Abbreviation = "СЗТУ",
                    Address = "Россия, г. Санкт-Петербург, ул. Якорная, д. 9, лит. А",
                    EmailAddress = "info@nwotu.ru",
                    PhoneNumber = "78123092265",
                    Description = "",
                    Website = "http://www.nwotu.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                    CityId = 79
                },
                new Class // 62
                {
                    Name = "Балтийский гуманитарный институт",
                    Abbreviation = "БГИ",
                    Address = "Россия, г. Санкт-Петербург, пр. Стачек, д. 72, лит. А",
                    EmailAddress = "info@bhi.spb.ru",
                    PhoneNumber = "78126476315",
                    Description = "",
                    Website = "http://bhi.spb.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                    CityId = 79
                },
                new Class // 63
                {
                    Name = "Санкт-Петербургская академия Следственного комитета Российской Федерации",
                    Abbreviation = "Санкт-Петербургская академия Следственного комитета",
                    Address = "Россия, г. Санкт-Петербург, наб. реки Мойки, д. 96",
                    EmailAddress = "uf@skspba.ru",
                    PhoneNumber = "78123311210",
                    Description = "",
                    Website = "http://skspba.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    CityId = 79
                },
                new Class // 64
                {
                    Name = "Санкт-Петербургская юридическая академия",
                    Abbreviation = "СЮА",
                    Address = "Россия, г. Санкт-Петербург, пр. Обуховской Обороны, д. 114, лит. А",
                    EmailAddress = "jurac.spb@mail.ru",
                    PhoneNumber = "78126770007",
                    Description = "",
                    Website = "https://jurac.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                    CityId = 79
                }
            });

            Context.SaveChanges();
        }
    }
}