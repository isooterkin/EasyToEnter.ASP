using EasyToEnter.ASP.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    // Модель "ВУЗ"
    [Display(Name = "Вариативность")]
    public class UniversityFavoritesViewModel
    {
        [Display(Name = "ВУЗ")]
        [JsonPropertyName("University")]
        public UniversityModel University { get; set; }



        [Display(Name = "Избранная")]
        [JsonPropertyName("Favorites")]
        public bool Favorites { get; set; } = false;



        [Display(Name = "Проходной балл")]
        [JsonPropertyName("PassingGrade")]
        public int PassingGrade { get; set; } = 0;



        [Display(Name = "Количество программ")]
        [JsonPropertyName("VariabilityCount")]
        public int VariabilityCount { get; set; } = 0;



        [Display(Name = "Количество мест")]
        [JsonPropertyName("NumberSeats")]
        public int NumberSeats { get; set; } = 0;
    }
}