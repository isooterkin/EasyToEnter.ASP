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
                    AddressId = 1,
                    EmailAddress = "office@technolog.edu.ru",
                    Description = "",
                    Website = "https://technolog.edu.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1
                },
                new Class // 2
                {
                    Name = "Санкт-Петербургский филиал Национального исследовательского университета «Высшая школа экономики»",
                    Abbreviation = "НИУ ВШЭ",
                    AddressId = 2,
                    EmailAddress = "abitur-spb@hse.ru",
                    Description = "",
                    Website = "https://spb.hse.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                    
                },
                new Class // 3
                {
                    Name = "Санкт-Петербургский политехнический университет Петра Великого",
                    Abbreviation = "СПбПУ",
                    AddressId = 3,
                    EmailAddress = "abitur@spbstu.ru",
                    Description = "",
                    Website = "http://www.spbstu.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                },
                new Class // 4
                {
                    Name = "Университет «Реавиз» в Санкт-Петербурге",
                    Abbreviation = "Реавиз в СПб",
                    AddressId = 4,
                    EmailAddress = "spb@reaviz.ru",
                    Description = "",
                    Website = "https://spbreaviz.ru",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                },
                new Class // 5
                {
                    Name = "Санкт-Петербургский Гуманитарный университет профсоюзов",
                    Abbreviation = "СПбГУП",
                    AddressId = 5,
                    EmailAddress = "pricom@gup.ru",
                    Description = "",
                    Website = "http://www.gup.ru",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                },
                new Class // 6
                {
                    Name = "Санкт-Петербургский государственный университет промышленных технологий и дизайна",
                    Abbreviation = "СПбГУПТД",
                    AddressId = 6,
                    EmailAddress = "priemcom@sutd.ru",
                    Description = "",
                    Website = "http://www.sutd.ru",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 7
                {
                    Name = "Художественно-технический институт",
                    Abbreviation = "ВХУТЕИН",
                    AddressId = 7,
                    EmailAddress = "abiturient@vhutein.ru",
                    Description = "",
                    Website = "https://vhutein.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                },
                new Class // 8
                {
                    Name = "Санкт-Петербургский реставрационно-строительный институт",
                    Abbreviation = "СПбРСИ",
                    AddressId = 8,
                    EmailAddress = "priem@spbiir.ru",
                    Description = "",
                    Website = "https://spbrsi.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                },
                new Class // 9
                {
                    Name = "Университет при Межпарламентской Ассамблее ЕврАзЭС",
                    Abbreviation = "Университет при МПА ЕврАзЭС",
                    AddressId = 9,
                    EmailAddress = "miep.priem@mail.ru",
                    Description = "",
                    Website = "https://www.miep.edu.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                },
                new Class // 10
                {
                    Name = "Санкт-Петербургский государственный университет телекоммуникаций им. проф. М.А. Бонч-Бруевича",
                    Abbreviation = "СПбГУТ",
                    AddressId = 10,
                    EmailAddress = "pk@sut.ru",
                    Description = "",
                    Website = "http://priem.sut.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                },
                new Class // 11
                {
                    Name = "Балтийский государственный технический университет «ВОЕНМЕХ» им. Д.Ф. Устинова",
                    Abbreviation = "БГТУ ВОЕНМЕХ им. Д.Ф.",
                    AddressId = 11,
                    EmailAddress = "admission@voenmeh.ru",
                    Description = "",
                    Website = "www.voenmeh.ru",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                },
                new Class // 12
                {
                    Name = "Северо-Западный институт управления - филиал Российской академии народного хозяйства и государственной службы при Президенте Российской Федерации",
                    Abbreviation = "Северо-Западный институт управления РАНХиГС",
                    AddressId = 12,
                    EmailAddress = "priem-sziu@ranepa.ru",
                    Description = "",
                    Website = "https://priem.spb.ranepa.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 13
                {
                    Name = "Санкт-Петербургский государственный экономический университет",
                    Abbreviation = "СПбГЭУ",
                    AddressId = 13,
                    EmailAddress = "abitura@unecon.ru",
                    Description = "",
                    Website = "https://unecon.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                },
                new Class // 14
                {
                    Name = "СПБГУ - Санкт-Петербургский государственный университет",
                    Abbreviation = "СПбГУ",
                    AddressId = 14,
                    EmailAddress = "abiturient@spbu.ru",
                    Description = "",
                    Website = "http://abiturient.spbu.ru",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                },
                new Class // 15
                {
                    Name = "Санкт-Петербургский государственный университет аэрокосмического приборостроения",
                    Abbreviation = "ГУАП",
                    AddressId = 15,
                    EmailAddress = "priem@guap.ru",
                    Description = "",
                    Website = "http://guap.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                },
                new Class // 16
                {
                    Name = "Санкт-Петербургский государственный электротехнический университет «ЛЭТИ» им. В.И. Ульянова (Ленина)",
                    Abbreviation = "СПбГЭТУ «ЛЭТИ»",
                    AddressId = 16,
                    EmailAddress = "prcom@etu.ru",
                    Description = "",
                    Website = "https://etu.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                },
                new Class // 17
                {
                    Name = "Российский государственный педагогический университет им. А.И. Герцена",
                    Abbreviation = "РГПУ им. А.И. Герцена",
                    AddressId = 17,
                    EmailAddress = "pk@herzen.spb.ru",
                    Description = "",
                    Website = "http://www.herzen.spb.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 18
                {
                    Name = "Петербургский государственный университет путей сообщения Императора Александра I",
                    Abbreviation = "ПГУПС",
                    AddressId = 18,
                    EmailAddress = "primkom@pgups.ru",
                    Description = "",
                    Website = "https://priem.pgups.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 19
                {
                    Name = "Российский государственный институт сценических искусств",
                    Abbreviation = "РГИСИ",
                    AddressId = 19,
                    EmailAddress = "pk@rgisi.ru",
                    Description = "",
                    Website = "http://www.rgisi.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 20
                {
                    Name = "Санкт-Петербургский университет технологий управления и экономики",
                    Abbreviation = "СПбУТУиЭ",
                    AddressId = 20,
                    EmailAddress = "rector@spbume.ru",
                    Description = "",
                    Website = "www.spbume.ru",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                },
                new Class // 21
                {
                    Name = "Северо-Западный филиал Российского государственного университета правосудия",
                    Abbreviation = "СЗФ РГУП",
                    AddressId = 21,
                    EmailAddress = "priem@szfrgup.ru",
                    Description = "",
                    Website = "http://nwb.rgup.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 22
                {
                    Name = "Санкт-Петербургский имени В.Б. Бобкова филиал Российской таможенной академии",
                    Abbreviation = "Санкт-Петербургский филиал РТА им. В.Б. Бобкова",
                    AddressId = 22,
                    EmailAddress = "odo@spbrta.ru",
                    Description = "",
                    Website = "https://spbrta.customs.gov.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 23
                {
                    Name = "Балтийская академия туризма и предпринимательства",
                    Abbreviation = "БАТиП",
                    AddressId = 23,
                    EmailAddress = "priem@batp.ru",
                    Description = "",
                    Website = "http://batp.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                },
                new Class // 24
                {
                    Name = "Санкт-Петербургский горный университет",
                    Abbreviation = "Горный университет",
                    AddressId = 24,
                    EmailAddress = "abitur@spmi.ru",
                    Description = "",
                    Website = "https://priem.spmi.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                },
                new Class // 25
                {
                    Name = "Российский государственный гидрометеорологический университет",
                    Abbreviation = "РГГМУ",
                    AddressId = 25,
                    EmailAddress = "dovus@rshu.ru",
                    Description = "",
                    Website = "http://www.rshu.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                },
                new Class // 26
                {
                    Name = "Санкт-Петербургский государственный аграрный университет",
                    Abbreviation = "СПбГАУ",
                    AddressId = 26,
                    EmailAddress = "pk_spbgau@mail.ru",
                    Description = "",
                    Website = "http://spbgau.ru",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 27
                {
                    Name = "Высшая школа менеджмента СПбГУ",
                    Abbreviation = "ВШМ СПбГУ",
                    AddressId = 27,
                    EmailAddress = "abitur@gsom.spbu.ru",
                    Description = "",
                    Website = "http://gsom.spbu.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                },
                new Class // 28
                {
                    Name = "Санкт-Петербургский государственный морской технический университет",
                    Abbreviation = "СПбГМТУ",
                    AddressId = 28,
                    EmailAddress = "priem@smtu.ru",
                    Description = "",
                    Website = "https://www.smtu.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                },
                new Class // 29
                {
                    Name = "Международный банковский институт имени Анатолия Собчака",
                    Abbreviation = "МБИ им. А. Собчака",
                    AddressId = 29,
                    EmailAddress = "ibispb@ibispb.ru",
                    Description = "",
                    Website = "https://www.ibispb.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                },
                new Class // 30
                {
                    Name = "Академия Русского балета имени А.Я. Вагановой",
                    Abbreviation = "АРБ им. А.Я.Вагановой",
                    AddressId = 30,
                    EmailAddress = "info@vaganovaacademy.ru",
                    Description = "",
                    Website = "http://www.vaganovaacademy.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 31
                {
                    Name = "Санкт-Петербургский институт (филиал) Всероссийского государственного университета юстиции (РПА Минюста России)",
                    Abbreviation = "Санкт-Петербургский институте (филиал) ВГУЮ (РПА Минюста России)",
                    AddressId = 31,
                    EmailAddress = "pk@szfrpa.ru",
                    Description = "",
                    Website = "https://spb.rpa-mu.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                },
                new Class // 32
                {
                    Name = "Национальный открытый институт г. Санкт-Петербург",
                    Abbreviation = "НОИ СПб",
                    AddressId = 32,
                    EmailAddress = "info@noironline.ru",
                    Description = "",
                    Website = "https://noironline.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                },
                new Class // 33
                {
                    Name = "Санкт-Петербургский государственный химико-фармацевтический университет",
                    Abbreviation = "СПХФУ",
                    AddressId = 33,
                    EmailAddress = "info@pharminnotech.com",
                    Description = "",
                    Website = "http://spcpu.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 34
                {
                    Name = "Государственный университет морского и речного флота имени адмирала С.О. Макарова",
                    Abbreviation = "ГУМРФ им. адм. С.О. Макарова",
                    AddressId = 34,
                    EmailAddress = "otd_o@gumrf.ru",
                    Description = "",
                    Website = "www.gumrf.ru",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                },
                new Class // 35
                {
                    Name = "Санкт-Петербургский государственный лесотехнический университет имени С.М. Кирова",
                    Abbreviation = "СПбГЛТУ им. С.М. Кирова",
                    AddressId = 35,
                    EmailAddress = "pricomlt@mail.ru",
                    Description = "",
                    Website = "https://spbftu.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 36
                {
                    Name = "Санкт-Петербургский государственный академический институт живописи, скульптуры и архитектуры имени И.Е. Репина при Российской академии художеств",
                    Abbreviation = "Институт имени И.Е. Репина",
                    AddressId = 36,
                    EmailAddress = "repinpriem@gmail.com",
                    Description = "",
                    Website = "http://www.artsacademy.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 37
                {
                    Name = "Санкт-Петербургская государственная консерватория им. Н.А. Римского-Корсакова",
                    Abbreviation = "СПбГК им. Н.А. Римского-Корсакова",
                    AddressId = 37,
                    EmailAddress = "rectorat@conservatory.ru",
                    Description = "",
                    Website = "http://www.conservatory.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 38
                {
                    Name = "Санкт-Петербургский национальный исследовательский Академический университет имени Ж.И. Алфёрова Российской академии наук (Алферовский университет)",
                    Abbreviation = "СПбАУ РАН им. Ж.И. Алфёрова",
                    AddressId = 38,
                    EmailAddress = "admission@spbau.ru",
                    Description = "",
                    Website = "http://spbau.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 39
                {
                    Name = "Русская христианская гуманитарная академия",
                    Abbreviation = "РХГА",
                    AddressId = 39,
                    EmailAddress = "abiturient@rhga.ru",
                    Description = "",
                    Website = "https://rhga.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                },
                new Class // 40
                {
                    Name = "Северо-Западный государственный медицинский университет имени И.И. Мечникова",
                    Abbreviation = "СЗГМУ им. И.И. Мечникова",
                    AddressId = 40,
                    EmailAddress = "rectorat@szgmu.ru",
                    Description = "",
                    Website = "http://szgmu.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 41
                {
                    Name = "Санкт-Петербургский государственный институт психологии и социальной работы",
                    Abbreviation = "СПбГИПСР",
                    AddressId = 41,
                    EmailAddress = "priem@gipsr.ru",
                    Description = "",
                    Website = "http://www.psysocwork.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 42
                {
                    Name = "Санкт-Петербургский университет Государственной противопожарной службы Министерства Российской Федерации по делам гражданской обороны, чрезвычайным ситуациям и ликвидации последствий стихийных бедствий",
                    Abbreviation = "Санкт-Петербургский университет ГПС МЧС России",
                    AddressId = 42,
                    EmailAddress = "baranov.n@igps.ru",
                    Description = "",
                    Website = "http://www.igps.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 43
                {
                    Name = "Санкт-Петербургский институт экономики и управления",
                    Abbreviation = "СПбИЭУ",
                    AddressId = 43,
                    EmailAddress = "spbiem@yandex.ru",
                    Description = "",
                    Website = "https://www.spbiem.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                },
                new Class // 44
                {
                    Name = "Санкт-Петербургский университет Федеральной службы исполнения наказаний",
                    Abbreviation = "Университет ФСИН России",
                    AddressId = 44,
                    EmailAddress = "spbu@fsin.gov.ru",
                    Description = "",
                    Website = "https://spbu.fsin.gov.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 45
                {
                    Name = "Первый Санкт-Петербургский государственный медицинский университет имени академика И.П. Павлова",
                    Abbreviation = "ПСПбГМУ им. И.П. Павлова",
                    AddressId = 45,
                    EmailAddress = "priemkom@spb-gmu.ru",
                    Description = "",
                    Website = "http://www.1spbgmu.ru/ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 46
                {
                    Name = "Ленинградский государственный университет имени А.С. Пушкина",
                    Abbreviation = "ЛГУ им. А.С. Пушкина",
                    AddressId = 46,
                    EmailAddress = "pushkin@lengu.ru",
                    Description = "",
                    Website = "http://lengu.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 47
                {
                    Name = "Санкт-Петербургский государственный университет гражданской авиации",
                    Abbreviation = "СПбГУ ГА",
                    AddressId = 47,
                    EmailAddress = "info@spbguga.ru",
                    Description = "",
                    Website = "http://www.spbguga.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 48
                {
                    Name = "Национальный государственный университет физической культуры, спорта и здоровья имени П.Ф. Лесгафта",
                    Abbreviation = "НГУ им. П.Ф. Лесгафта",
                    AddressId = 48,
                    EmailAddress = "abiturientlesgaft@lesgaft.spb.ru",
                    Description = "",
                    Website = "http://lesgaft.spb.ru",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 49
                {
                    Name = "Санкт-Петербургский государственный институт культуры",
                    Abbreviation = "СПбГИК",
                    AddressId = 49,
                    EmailAddress = "pk@spbgik.ru",
                    Description = "",
                    Website = "http://www.spbgik.ru",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 50
                {
                    Name = "Высшая школа народных искусств (академия)",
                    Abbreviation = "ВШНИ",
                    AddressId = 50,
                    EmailAddress = "vshni@mail.ru",
                    Description = "",
                    Website = "http://www.vshni.ru",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 51
                {
                    Name = "Санкт-Петербургская государственная художественно-промышленная академия имени А.Л. Штиглица",
                    Abbreviation = "СПГХПА им. А.Л. Штиглица",
                    AddressId = 51,
                    EmailAddress = "assistant@ghpa.ru",
                    Description = "",
                    Website = "http://www.ghpa.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 52
                {
                    Name = "Санкт-Петербургский филиал Финансового университета при Правительстве Российской Федерации",
                    Abbreviation = "Санкт-Петербургский филиал Финуниверситета​",
                    AddressId = 52,
                    EmailAddress = "spb_mail@fa.ru",
                    Description = "",
                    Website = "http://www.fa.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 53
                {
                    Name = "Институт медицинского образования Национального медицинского исследовательского центра имени В. А. Алмазова",
                    Abbreviation = "Институт медицинского образования НМИЦ им. В. А. Алмазова",
                    AddressId = 53,
                    EmailAddress = "pk@almazovcentre.ru",
                    Description = "",
                    Website = "http://education.almazovcentre.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 54
                {
                    Name = "Санкт-Петербургский медико-социальный институт",
                    Abbreviation = "СПбМСИ",
                    AddressId = 54,
                    EmailAddress = "abiturient@medinstitut.org",
                    Description = "",
                    Website = "https://medinstitut.org/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                },
                new Class // 55
                {
                    Name = "Европейский университет в Санкт-Петербурге",
                    Abbreviation = "ЕУСПб",
                    AddressId = 55,
                    EmailAddress = "admissions@eu.spb.ru",
                    Description = "",
                    Website = "https://eusp.org/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                },
                new Class // 56
                {
                    Name = "Санкт-Петербургский государственный педиатрический медицинский университет",
                    Abbreviation = "СПбГПМУ",
                    AddressId = 56,
                    EmailAddress = "gpmu_priem@mail.ru",
                    Description = "",
                    Website = "http://gpmu.org/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 57
                {
                    Name = "Национальный исследовательский университет ИТМО",
                    Abbreviation = "Университет ИТМО",
                    AddressId = 57,
                    EmailAddress = "abit@itmo.ru",
                    Description = "",
                    Website = "http://www.ifmo.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                },
                new Class // 58
                {
                    Name = "Санкт-Петербургский государственный архитектурно-строительный университет",
                    Abbreviation = "СПбГАСУ",
                    AddressId = 58,
                    EmailAddress = "prc@spbgasu.ru",
                    Description = "",
                    Website = "http://www.spbgasu.ru",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 59
                {
                    Name = "Санкт-Петербургский государственный университет ветеринарной медицины",
                    Abbreviation = "СПбГУВМ",
                    AddressId = 59,
                    EmailAddress = "spbgavm-priem@mail.ru",
                    Description = "",
                    Website = "https://www.spbgavm.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 60
                {
                    Name = "Санкт-Петербургский государственный институт кино и телевидения",
                    Abbreviation = "СПбГИКиТ",
                    AddressId = 60,
                    EmailAddress = "priem@gukit.ru",
                    Description = "",
                    Website = "http://www.gukit.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 1,
                },
                new Class // 61
                {
                    Name = "Северо-Западный открытый технический университет",
                    Abbreviation = "СЗТУ",
                    AddressId = 61,
                    EmailAddress = "info@nwotu.ru",
                    Description = "",
                    Website = "http://www.nwotu.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                },
                new Class // 62
                {
                    Name = "Балтийский гуманитарный институт",
                    Abbreviation = "БГИ",
                    AddressId = 62,
                    EmailAddress = "info@bhi.spb.ru",
                    Description = "",
                    Website = "http://bhi.spb.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                },
                new Class // 63
                {
                    Name = "Санкт-Петербургская академия Следственного комитета Российской Федерации",
                    Abbreviation = "Санкт-Петербургская академия Следственного комитета",
                    AddressId = 63,
                    EmailAddress = "uf@skspba.ru",
                    Description = "",
                    Website = "http://skspba.ru/",
                    MilitaryDepartment = true,
                    AccreditationId = 1,
                },
                new Class // 64
                {
                    Name = "Санкт-Петербургская юридическая академия",
                    Abbreviation = "СЮА",
                    AddressId = 64,
                    EmailAddress = "jurac.spb@mail.ru",
                    Description = "",
                    Website = "https://jurac.ru/",
                    MilitaryDepartment = false,
                    AccreditationId = 2,
                }
            });

            Context.SaveChanges();
        }
    }
}