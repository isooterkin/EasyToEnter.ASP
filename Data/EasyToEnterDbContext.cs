using EasyToEnter.ASP.Models.Models;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

namespace EasyToEnter.ASP.Data
{
    public class EasyToEnterDbContext: DbContext
    {
        // Конструктор
        public EasyToEnterDbContext(DbContextOptions options) : base(options) { }

        // Таблица "Формат"
        public DbSet<FormatModel> Format { get; set; }

        // Таблица "Оплата"
        public DbSet<PaymentModel> Payment { get; set; }

        // Таблица "Форма"
        public DbSet<FormModel> Form { get; set; }

        // Таблица "Предмет"
        public DbSet<SubjectModel> Subject { get; set; }

        // Таблица "Субъект"
        public DbSet<RegionModel> Region { get; set; }

        // Таблица "Город"
        public DbSet<CityModel> City { get; set; }

        // Таблица "Уровень"
        public DbSet<LevelModel> Level { get; set; }

        // Таблица "Группа"
        public DbSet<GroupModel> Group { get; set; }

        // Таблица "Направление"
        public DbSet<DirectionModel> Direction { get; set; }

        // Таблица "Направленность"
        public DbSet<FocusModel> Focus { get; set; }

        // Таблица "Наука"
        public DbSet<ScienceModel> Science { get; set; }

        // Таблица "Уровень - Направленность"
        public DbSet<LevelFocusModel> LevelFocus { get; set; }
    }
}