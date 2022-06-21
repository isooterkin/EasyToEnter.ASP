using EasyToEnter.ASP.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    // Модель "Вакансия"
    [Display(Name = "Вакансия")]
    public class VacancyFavoritesViewModel
    {
        [Display(Name = "Вакансия")]
        [JsonPropertyName("Vacancy")]
        public VacancyModel Vacancy { get; set; }



        [Display(Name = "Избранная")]
        [JsonPropertyName("Favorites")]
        public bool Favorites { get; set; } = false;
    }
}