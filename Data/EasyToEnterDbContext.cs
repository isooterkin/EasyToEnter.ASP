using EasyToEnter.ASP.Models.Models;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

namespace EasyToEnter.ASP.Data
{
    public class EasyToEnterDbContext: DbContext
    {
        // Конструктор
        public EasyToEnterDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressModel>()
                .HasMany(a => a.Dormitorys)
                .WithOne(a => a.AddressModel)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<SubjectModel>()
                .HasMany(a => a.SubjectReplacements)
                .WithOne(a => a.SubjectModel)
                .OnDelete(DeleteBehavior.ClientCascade);
        }

        // Таблица "Уровень"
        public DbSet<LevelModel> Level { get; set; }

        // Таблица "Группа"
        public DbSet<GroupModel> Group { get; set; }

        // Таблица "Направление"
        public DbSet<DirectionModel> Direction { get; set; }

        // Таблица "Направленность"
        public DbSet<FocusModel> Focus { get; set; }

        // Таблица "Тип профессии"
        public DbSet<TypeProfessionModel> TypeProfession { get; set; }

        // Таблица "Профессия"
        public DbSet<ProfessionModel> Profession { get; set; }

        // Таблица "Профессия - Направленность"
        public DbSet<ProfessionFocusModel> ProfessionFocus { get; set; }

        // Таблица "Наука"
        public DbSet<ScienceModel> Science { get; set; }

        // Таблица "Уровень - Направленность"
        public DbSet<LevelFocusModel> LevelFocus { get; set; }

        // Таблица "Субъект"
        public DbSet<RegionModel> Region { get; set; }

        // Таблица "Город"
        public DbSet<CityModel> City { get; set; }

        // Таблица "Специализация"
        public DbSet<SpecializationModel> Specialization { get; set; }

        // Таблица "Область"
        public DbSet<AreaModel> Area { get; set; }

        // Таблица "Аккредитация"
        public DbSet<AccreditationModel> Accreditation { get; set; }

        // Таблица "Формат"
        public DbSet<FormatModel> Format { get; set; }

        // Таблица "Оплата"
        public DbSet<PaymentModel> Payment { get; set; }

        // Таблица "Форма"
        public DbSet<FormModel> Form { get; set; }

        // Таблица "Предмет"
        public DbSet<SubjectModel> Subject { get; set; }

        // Таблица "Предмет направленности ВУЗа"
        public DbSet<SubjectFocusUniversityModel> SubjectFocusUniversity { get; set; }

        // Таблица "Предмет на замену"
        public DbSet<SubjectReplacementModel> SubjectReplacement { get; set; }

        // Таблица "Адресс"
        public DbSet<AddressModel> Address { get; set; }

        // Таблица "ВУЗ"
        public DbSet<UniversityModel> University { get; set; }

        // Таблица "Контактный номер"
        public DbSet<PhoneNumberUniversityModel> PhoneNumberUniversity { get; set; }

        // Таблица "Общежитие"
        public DbSet<DormitoryModel> Dormitory { get; set; }

        // Таблица "Область - Направленность"
        public DbSet<AreaFocusModel> AreaFocus { get; set; }

        // Таблица "Специализация - ВУЗ"
        public DbSet<SpecializationUniversityModel> SpecializationUniversity { get; set; }

        // Таблица "Направленность ВУЗа"
        public DbSet<FocusUniversityModel> FocusUniversity { get; set; }

        // Таблица "Дисциплина"
        public DbSet<DisciplineModel> Discipline { get; set; }

        // Таблица "Дисциплина направленности ВУЗа"
        public DbSet<DisciplineFocusUniversityModel> DisciplineFocusUniversity { get; set; }

        // Таблица "Вариативность"
        public DbSet<VariabilityModel> Variability { get; set; }

        // Таблица "История вариативности"
        public DbSet<HistoryVariabilityModel> HistoryVariability { get; set; }
    }
}