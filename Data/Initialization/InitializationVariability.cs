using Class = EasyToEnter.ASP.Models.Models.VariabilityModel;

namespace EasyToEnter.ASP.Data.Initialization
{
    public class InitializationVariability
    {
        public static void Initialize(EasyToEnterDbContext Context)
        {
            Context.AddRange(new Class[]
            {
                new Class // 1
                {
                    FocusUniversityId = 1,
                    FormId = 3, // заочно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = false,
                    TrainingPeriod = 5
                },
                new Class // 2
                {
                    FocusUniversityId = 1,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 1, // бюджет
                    EntranceExams = false,
                    TrainingPeriod = 4
                },
                new Class // 3
                {
                    FocusUniversityId = 1,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = false,
                    TrainingPeriod = 4
                },
                new Class // 4
                {
                    FocusUniversityId = 1,
                    FormId = 3, // заочно
                    FormatId = 2, // полный курс
                    PaymentId = 1, // бюджет
                    EntranceExams = false,
                    TrainingPeriod = 5
                },
                new Class // 5
                {
                    FocusUniversityId = 2,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = false,
                    TrainingPeriod = 4
                },
                new Class // 6
                {
                    FocusUniversityId = 2,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 1, // бюджет
                    EntranceExams = false,
                    TrainingPeriod = 4
                },
                new Class // 7
                {
                    FocusUniversityId = 3,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 1, // бюджет
                    EntranceExams = false,
                    TrainingPeriod = 4
                },
                new Class // 8
                {
                    FocusUniversityId = 3,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = false,
                    TrainingPeriod = 4
                },
                new Class // 9
                {
                    FocusUniversityId = 4,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = false,
                    TrainingPeriod = 4
                },
                new Class // 10
                {
                    FocusUniversityId = 4,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 1, // бюджет
                    EntranceExams = false,
                    TrainingPeriod = 4
                },
                new Class // 11
                {
                    FocusUniversityId = 5,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = false,
                    TrainingPeriod = 2
                },
                new Class // 12
                {
                    FocusUniversityId = 5,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 1, // бюджет
                    EntranceExams = false,
                    TrainingPeriod = 2
                },
                new Class // 13
                {
                    FocusUniversityId = 5,
                    FormId = 3, // заочно
                    FormatId = 2, // полный курс
                    PaymentId = 1, // бюджет
                    EntranceExams = false,
                    TrainingPeriod = 3
                },
                new Class // 14
                {
                    FocusUniversityId = 5,
                    FormId = 3, // заочно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = false,
                    TrainingPeriod = 3
                },
                new Class // 15
                {
                    FocusUniversityId = 6,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 1, // бюджет
                    EntranceExams = false,
                    TrainingPeriod = 4
                },
                new Class // 16
                {
                    FocusUniversityId = 6,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = false,
                    TrainingPeriod = 4
                },
                new Class // 16
                {
                    FocusUniversityId = 6,
                    FormId = 3, // заочно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = false,
                    TrainingPeriod = 5
                },
                new Class // 17
                {
                    FocusUniversityId = 7,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = false,
                    TrainingPeriod = 4
                },
                new Class // 18
                {
                    FocusUniversityId = 7,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 1, // бюджет
                    EntranceExams = false,
                    TrainingPeriod = 4
                },
                new Class // 19
                {
                    FocusUniversityId = 8,
                    FormId = 5, // очно-заочный
                    FormatId = 3, // ускоренное
                    PaymentId = 2, // платно
                    EntranceExams = false,
                    TrainingPeriod = 3
                },
                new Class // 20
                {
                    FocusUniversityId = 9,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 1, // бюджет
                    EntranceExams = false,
                    TrainingPeriod = 4
                },
                new Class // 21
                {
                    FocusUniversityId = 9,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = false,
                    TrainingPeriod = 4
                },
                new Class // 22
                {
                    FocusUniversityId = 10,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = false,
                    TrainingPeriod = 4
                },
                new Class // 23
                {
                    FocusUniversityId = 10,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 1, // бюджет
                    EntranceExams = false,
                    TrainingPeriod = 4
                },
                new Class // 24
                {
                    FocusUniversityId = 11,
                    FormId = 3, // заочно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = false,
                    TrainingPeriod = 5
                },
                new Class // 25
                {
                    FocusUniversityId = 11,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = false,
                    TrainingPeriod = 4
                },
                new Class // 26
                {
                    FocusUniversityId = 11,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 1, // бюджет
                    EntranceExams = false,
                    TrainingPeriod = 4
                },
                new Class // 27
                {
                    FocusUniversityId = 12,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 1, // бюджет
                    EntranceExams = true,
                    TrainingPeriod = 2
                },
                new Class // 28
                {
                    FocusUniversityId = 12,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = true,
                    TrainingPeriod = 2
                },
                new Class // 29
                {
                    FocusUniversityId = 13,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = true,
                    TrainingPeriod = 2
                },
                new Class // 30
                {
                    FocusUniversityId = 13,
                    FormId = 3, // заочно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = true,
                    TrainingPeriod = 3
                },
                new Class // 31
                {
                    FocusUniversityId = 13,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 1, // бюджет
                    EntranceExams = true,
                    TrainingPeriod = 2
                },
                new Class // 32
                {
                    FocusUniversityId = 14,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 1, // бюджет
                    EntranceExams = true,
                    TrainingPeriod = 2
                },
                new Class // 33
                {
                    FocusUniversityId = 14,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = true,
                    TrainingPeriod = 2
                },
                new Class // 34
                {
                    FocusUniversityId = 15,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = true,
                    TrainingPeriod = 2
                },
                new Class // 35
                {
                    FocusUniversityId = 15,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 1, // бюджет
                    EntranceExams = true,
                    TrainingPeriod = 2
                },
                new Class // 36
                {
                    FocusUniversityId = 16,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 1, // бюджет
                    EntranceExams = true,
                    TrainingPeriod = 2
                },
                new Class // 37
                {
                    FocusUniversityId = 16,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = true,
                    TrainingPeriod = 2
                },
                new Class // 38
                {
                    FocusUniversityId = 17,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = true,
                    TrainingPeriod = 2
                },
                new Class // 39
                {
                    FocusUniversityId = 17,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 1, // бюджет
                    EntranceExams = true,
                    TrainingPeriod = 2
                },
                new Class // 40
                {
                    FocusUniversityId = 18,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 1, // бюджет
                    EntranceExams = true,
                    TrainingPeriod = 2
                },
                new Class // 41
                {
                    FocusUniversityId = 18,
                    FormId = 4, // очно
                    FormatId = 2, // полный курс
                    PaymentId = 2, // платно
                    EntranceExams = true,
                    TrainingPeriod = 2
                }
            });

            Context.SaveChanges();
        }
    }
}