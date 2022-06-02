using EasyToEnter.ASP.Models.Dependence;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "История вариативности")]
    [Index(nameof(VariabilityId), nameof(Year), IsUnique = true)]
    public class HistoryVariabilityModel: ModelWithId
    {
        [Required(ErrorMessage = "Укажите год.")]
        [Display(Name = "Год")]
        [JsonPropertyName("Year")]
        public int Year { get; set; }



        [Required(ErrorMessage = "Укажите проходной балл.")]
        [Display(Name = "Проходной балл")]
        [JsonPropertyName("PassingGrade")]
        public int PassingGrade { get; set; }



        [Required(ErrorMessage = "Укажите стоимость обучения.")]
        [Display(Name = "Стоимость обучения")]
        [JsonPropertyName("Tuition")]
        public int Tuition { get; set; } = 0;



        [Required(ErrorMessage = "Укажите количество мест.")]
        [Display(Name = "Количество мест")]
        [JsonPropertyName("NumberSeats")]
        public int NumberSeats { get; set; }



        [Display(Name = "Вариативность")]
        [Required(ErrorMessage = "Укажите вариативность.")]
        [JsonPropertyName("VariabilityId")]
        public int VariabilityId { get; set; }
        [ForeignKey(nameof(VariabilityId))]
        [Display(Name = "Вариативность")]
        [JsonPropertyName("VariabilityModel")]
        public VariabilityModel? VariabilityModel { get; set; }
    }
}