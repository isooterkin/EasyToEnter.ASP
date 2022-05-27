using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Models.Models
{
    // Модель "История вариативности"
    [Display(Name = "История вариативности")]
    [Index(nameof(VariabilityId), nameof(Year), IsUnique = true)]
    public class HistoryVariabilityModel: ModelWithId
    {
        [Required(ErrorMessage = "Укажите год.")]
        [Display(Name = "Год")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Укажите проходной балл.")]
        [Display(Name = "Проходной балл")]
        public int PassingGrade { get; set; }

        [Required(ErrorMessage = "Укажите стоимость обучения.")]
        [Display(Name = "Стоимость обучения")]
        public int Tuition { get; set; } = 0;

        [Required(ErrorMessage = "Укажите количество мест.")]
        [Display(Name = "Количество мест")]
        public int NumberSeats { get; set; }

        // Внешний ключ модели "Вариативность"
        [Display(Name = "Вариативность")]
        [Required(ErrorMessage = "Укажите вариативность.")]
        public int VariabilityId { get; set; }
        [ForeignKey(nameof(VariabilityId))]
        [Display(Name = "Вариативность")]
        public VariabilityModel? VariabilityModel { get; set; }
    }
}